using System.Text.Json;
using System.Text.Json.Nodes;
using Ivy.Apps;
using Ivy.Auth;
using Ivy.Core;
using Ivy.Helpers;
using Ivy.Hooks;
using Ivy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Ivy;

public class AppHub(
    Server server, 
    IClientNotifier clientNotifier,
    IContentBuilder contentBuilder,
    AppSessionStore sessionStore,
    ILogger<AppHub> logger
    ) : Hub
{
    public static string GetAppId(Server server, HttpContext httpContext)
    {
        string? appId = server.DefaultAppId;
            
        if(httpContext!.Request.Query.ContainsKey("appId"))
        {
            appId = httpContext!.Request.Query["appId"].ToString();
        }
        
        if (string.IsNullOrEmpty(appId))
        {
            appId = server.DefaultAppId ?? server.AppRepository.GetAppOrDefault(null).Id;
        }

        return appId;
    }

    public static string GetMachineId(HttpContext httpContext)
    {
        if(httpContext!.Request.Query.ContainsKey("machineId"))
        {
            return httpContext!.Request.Query["machineId"].ToString().NullIfEmpty() ?? throw new Exception("Missing machineId in request.");
        }
        
        throw new Exception("Missing machineId in request.");
    }
    
    public static string? GetParentId(HttpContext httpContext)
    {
        if(httpContext!.Request.Query.ContainsKey("parentId"))
        {
            return httpContext!.Request.Query["parentId"].ToString().NullIfEmpty();
        }

        return null;
    }

    public AppArgs GetAppArgs(string connectionId, string appId, HttpContext httpContext)
    {
        string? appArgs = null;
        if(httpContext!.Request.Query.ContainsKey("appArgs"))
        {
            appArgs = httpContext!.Request.Query["appArgs"].ToString().NullIfEmpty();
        }

        HttpRequest request = httpContext.Request;
        return new AppArgs(connectionId, appId, appArgs ?? server.Args?.Args, request.Scheme, request.Host.Value!);
    }
    
    public override async Task OnConnectedAsync()
    {
        var appServices = new ServiceCollection();
        
        var httpContext = Context.GetHttpContext()!;
        var appId = GetAppId(server, httpContext);
        
        var isAuthProtected = server.AuthProviderType != null;
        if (isAuthProtected)
        {
            var authProvider = server.Services.BuildServiceProvider().GetService<IAuthProvider>() ?? throw new Exception("IAuthProvider not found");
            var jwt = httpContext.Request.Cookies["jwt"].NullIfEmpty();

            // TODO: handle deserialization errors
            var authToken = jwt != null
                ? JsonSerializer.Deserialize<AuthToken>(jwt)
                : null;

            if (string.IsNullOrEmpty(authToken?.Jwt))
            {
                appId = AppIds.Auth;
            }
            else
            {
                var validJwt = await authProvider.ValidateJwtAsync(authToken.Jwt);
                if (!validJwt)
                {
                    appId = AppIds.Auth;
                }
            }
            appServices.AddSingleton<IAuthService>(s => new AuthService(authProvider, authToken));
        }
        
        var appArgs = GetAppArgs(Context.ConnectionId, appId, httpContext);
        var appDescriptor = server.GetApp(appId);
        
        logger.LogInformation($"Connected: {Context.ConnectionId} [{appId}]");
        
        var clientProvider = new ClientProvider(new ClientSender(clientNotifier, Context.ConnectionId));
        
        appServices.AddSingleton(typeof(IContentBuilder), contentBuilder);
        appServices.AddSingleton(typeof(IAppRepository), server.AppRepository);
        appServices.AddSingleton(typeof(IDownloadService), new DownloadService(Context.ConnectionId));
        appServices.AddSingleton(typeof(IClientProvider), clientProvider);
        appServices.AddTransient<IWebhookRegistry, WebhookController>();
        appServices.AddSingleton(appDescriptor);
        appServices.AddSingleton(appArgs);
        appServices.AddTransient<SignalRouter>(_ => new SignalRouter(sessionStore));
        
        var serviceProvider = new CompositeServiceProvider(appServices, server.Services); 
        
        var app = appDescriptor.CreateApp();
        
        var widgetTree = new WidgetTree(app, contentBuilder, serviceProvider);
        
        var appState = new AppSession
        {
            AppId = appId,
            MachineId = GetMachineId(httpContext),
            ParentId = GetParentId(httpContext),
            AppDescriptor = appDescriptor,
            App = app,
            ConnectionId = Context.ConnectionId,
            WidgetTree = widgetTree,
            ContentBuilder = contentBuilder,
            AppServices = serviceProvider,
            LastInteraction = DateTime.UtcNow
        };

        async void OnWidgetTreeChanged(WidgetTreeChanged[] changes)
        {
            logger.LogDebug($"> Update");
            await clientNotifier.NotifyClientAsync(appState.ConnectionId, "Update", changes);
        }

        appState.TrackDisposable(widgetTree.Subscribe(OnWidgetTreeChanged));
        
        sessionStore.Sessions[Context.ConnectionId] = appState;
        
        await base.OnConnectedAsync();

        try
        {
            await widgetTree.BuildAsync();
            logger.LogInformation($"Refresh: {Context.ConnectionId} [{appId}]");
            await Clients.Caller.SendAsync("Refresh", new
            {
                Widgets = widgetTree.GetWidgets().Serialize(), 
                appDescriptor.RemoveIvyBranding
            });
        }
        catch (Exception e)
        {
            var tree = new WidgetTree(new ErrorView(e), contentBuilder, serviceProvider);
            await tree.BuildAsync();
            await Clients.Caller.SendAsync("Refresh", new
            {
                Widgets = tree.GetWidgets().Serialize(), 
                appDescriptor.RemoveIvyBranding
            });
        }
    }

    public override Task OnDisconnectedAsync(System.Exception? exception)
    {
        if (sessionStore.Sessions.TryRemove(Context.ConnectionId, out var appState))
        {
            appState.Dispose();
        }
        
        return base.OnDisconnectedAsync(exception);
    }
    
    public void HotReload()
    {
        if (sessionStore.Sessions.TryGetValue(Context.ConnectionId, out var appSession))
        {
            appSession.LastInteraction = DateTime.UtcNow;
            logger.LogInformation($"HotReload: {Context.ConnectionId} [{appSession.AppId}]");
            try
            {
                appSession.WidgetTree.HotReload();
            }
            catch (Exception e)
            {
                logger.LogError(e, "HotReload failed.");
            }
        }
        else
        {
            logger.LogWarning($"HotReload: {Context.ConnectionId} [Not Found]");
        }
    }
    
    public async Task Event(string eventName, string widgetId, JsonArray? args)
    {
        try
        {
            logger.LogInformation($"Event: {eventName} {widgetId} {args}");
            var appSession = sessionStore.Sessions[Context.ConnectionId];
            
            if (server.AuthProviderType != null)
            {
                if (appSession.AppId != AppIds.Auth)
                {
                    var authProvider = server.Services.BuildServiceProvider()
                                           .GetService<IAuthProvider>() ??
                                       throw new Exception("IAuthProvider not found");

                    var jwt = Context.GetHttpContext()!.Request.Cookies["jwt"].NullIfEmpty();

                    // TODO: handle deserialization errors
                    var authToken = jwt != null
                        ? JsonSerializer.Deserialize<AuthToken>(jwt)
                        : null;

                    if (string.IsNullOrEmpty(authToken?.Jwt) || !await authProvider.ValidateJwtAsync(authToken.Jwt))
                    {
                        logger.LogWarning(
                            "Invalid JWT for event from {ConnectionId}. Aborting.",
                            Context.ConnectionId);
                        Context.Abort();
                        return;
                    }
                }
            }
            
            appSession.LastInteraction = DateTime.UtcNow;
            if (!appSession.WidgetTree.TriggerEvent(widgetId, eventName, args ?? new JsonArray()))
            {
                logger.LogWarning($"Event '{eventName}' for Widget '{widgetId}' not found.");
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Event trigger failed.");
        }
    }
}

public class ClientSender(IClientNotifier clientNotifier, string connectionId) : IClientSender
{
    public void Send(string method, object? data)
    {
        _ = clientNotifier.NotifyClientAsync(connectionId, method, data);
    }
}

public class ClientProvider(IClientSender sender) : IClientProvider
{
    public IClientSender Sender { get; set; } = sender;
}
