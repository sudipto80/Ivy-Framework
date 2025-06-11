﻿using Ivy.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ivy.Auth;

public class AuthService(IAuthProvider authProvider, AuthToken? token) : IAuthService
{
    public async Task<AuthToken?> LoginAsync(string email, string password)
    {
        return await authProvider.LoginAsync(email, password);
    }

    public Task<Uri> GetOAuthUriAsync(string optionId, Uri callbackUri)
    {
        return authProvider.GetOAuthUriAsync(optionId, callbackUri);
    }

    public Task<AuthToken?> HandleOAuthCallbackAsync(HttpRequest request)
    { 
        return authProvider.HandleOAuthCallbackAsync(request);
    }

    public Task LogoutAsync()
    {
        if (string.IsNullOrWhiteSpace(token?.Jwt))
        {
            return null!;
        }
        
        return authProvider.LogoutAsync(token.Jwt);
    }

    public async Task<UserInfo?> GetUserInfoAsync()
    {
        if (string.IsNullOrWhiteSpace(token?.Jwt))
        {
            return null!;
        }
        
        //todo: cache this!
        
        return await authProvider.GetUserInfoAsync(token.Jwt);
    }

    public AuthOption[] GetAuthOptions()
    {
        return authProvider.GetAuthOptions();
    }
}
