using Ivy.Shared;

namespace Ivy.Samples.Apps.Widgets.Inputs;

[App(icon: Icons.PaintBucket, path: ["Widgets", "Inputs"])]
public class ColorInputApp : SampleBase
{
    protected override object? BuildSample()
    {
        var variants = CreateVariantsSection();
        var dataBinding = CreateDataBindingTests();
        var formatTests = CreateFormatTests();
        var nonGenericConstructor = CreateNonGenericConstructorSection();

        return Layout.Vertical()
               | Text.H1("ColorInput")
               | Text.H2("Non-Generic Constructor")
               | nonGenericConstructor
               | Text.H2("Variants")
               | variants
               | Text.H2("Format Tests")
               | formatTests
               | Text.H2("Data Binding")
               | dataBinding
            ;
    }

    private object CreateVariantsSection()
    {
        var textState = UseState("#381ff4");
        var pickerState = UseState("#dd5860");
        var bothState = UseState("#6637d1");
        var nullTextState = UseState((string?)null);
        var nullPickerState = UseState((string?)null);
        var nullBothState = UseState((string?)null);

        return Layout.Grid().Columns(6)
            | Text.InlineCode("")
            | Text.InlineCode("Default")
            | Text.InlineCode("Invalid")
            | Text.InlineCode("Disabled")
            | Text.InlineCode("Nullable")
            | Text.InlineCode("Nullable + Invalid")

            | Text.InlineCode("Text Only")
            | textState.ToColorInput().Variant(ColorInputVariant.Text)
            | textState.ToColorInput().Variant(ColorInputVariant.Text).Invalid("Invalid color")
            | textState.ToColorInput().Variant(ColorInputVariant.Text).Disabled()
            | nullTextState.ToColorInput().Variant(ColorInputVariant.Text)
            | nullTextState.ToColorInput().Variant(ColorInputVariant.Text).Invalid("Invalid color")

            | Text.InlineCode("Picker Only")
            | pickerState.ToColorInput().Variant(ColorInputVariant.Picker)
            | pickerState.ToColorInput().Variant(ColorInputVariant.Picker).Invalid("Invalid color")
            | pickerState.ToColorInput().Variant(ColorInputVariant.Picker).Disabled()
            | nullPickerState.ToColorInput().Variant(ColorInputVariant.Picker)
            | nullPickerState.ToColorInput().Variant(ColorInputVariant.Picker).Invalid("Invalid color")

            | Text.InlineCode("Text and Picker")
            | bothState.ToColorInput().Variant(ColorInputVariant.TextAndPicker)
            | bothState.ToColorInput().Variant(ColorInputVariant.TextAndPicker).Invalid("Invalid color")
            | bothState.ToColorInput().Variant(ColorInputVariant.TextAndPicker).Disabled()
            | nullBothState.ToColorInput().Variant(ColorInputVariant.TextAndPicker)
            | nullBothState.ToColorInput().Variant(ColorInputVariant.TextAndPicker).Invalid("Invalid color");
    }

    private object CreateNonGenericConstructorSection()
    {
        var state1 = UseState("#ff0000");
        var state2 = UseState("#00ff00");
        var state3 = UseState("#0000ff");

        return Layout.Grid().Columns(3)
               | Text.InlineCode("Method")
               | Text.InlineCode("ColorInput")
               | Text.InlineCode("State Value")

               | Text.InlineCode("Default Constructor")
               | new ColorInput()
               | Text.InlineCode("No state")

               | Text.InlineCode("With Placeholder")
               | new ColorInput("Select a color")
               | Text.InlineCode("No state")

               | Text.InlineCode("With State Binding")
               | state1.ToColorInput()
               | Text.InlineCode(state1.Value)

               | Text.InlineCode("Disabled")
               | new ColorInput(disabled: true)
               | Text.InlineCode("No state")

               | Text.InlineCode("Text Only Variant")
               | new ColorInput(variant: ColorInputVariant.Text)
               | Text.InlineCode("No state")

               | Text.InlineCode("Picker Only Variant")
               | new ColorInput(variant: ColorInputVariant.Picker)
               | Text.InlineCode("No state")

               | Text.InlineCode("Full Constructor")
               | new ColorInput(
                   placeholder: "Choose your color",
                   disabled: false,
                   variant: ColorInputVariant.TextAndPicker)
               | Text.InlineCode("No state");
    }

    private object CreateFormatTests()
    {
        var hexState = UseState("#ff0000");
        var rgbState = UseState("rgb(255, 0, 0)");
        var oklchState = UseState("oklch(0.5, 0.2, 240)");
        var enumState = UseState(Colors.Red);

        return Layout.Grid().Columns(4)
               | Text.InlineCode("Format")
               | Text.InlineCode("Input")
               | Text.InlineCode("Display Value")
               | Text.InlineCode("Stored Value")

               | Text.InlineCode("Hex")
               | hexState.ToColorInput()
               | Text.InlineCode(hexState.Value)
               | Text.InlineCode(hexState.Value)

               | Text.InlineCode("RGB")
               | rgbState.ToColorInput()
               | Text.InlineCode(rgbState.Value)
               | Text.InlineCode(ConvertToHex(rgbState.Value))

               | Text.InlineCode("OKLCH")
               | oklchState.ToColorInput()
               | Text.InlineCode(oklchState.Value)
               | Text.InlineCode(ConvertToHex(oklchState.Value))

               | Text.InlineCode("Enum")
               | enumState.ToColorInput()
               | Text.InlineCode(enumState.Value.ToString())
               | Text.InlineCode(ConvertToHex(enumState.Value.ToString()))
            ;
    }

    private object CreateDataBindingTests()
    {
        var colorTypes = new (string TypeName, object NonNullableState, object NullableState)[]
        {
            ("string", UseState("#ff0000"), UseState((string?)null)),
            ("Colors", UseState(Colors.Red), UseState((Colors?)null))
        };

        var gridItems = new List<object>
        {
            Text.InlineCode("Type"),
            Text.InlineCode("Non-Nullable"),
            Text.InlineCode("State"),
            Text.InlineCode("Type"),
            Text.InlineCode("Nullable"),
            Text.InlineCode("State")
        };

        foreach (var (typeName, nonNullableState, nullableState) in colorTypes)
        {
            // Non-nullable columns (first 3)
            gridItems.Add(Text.InlineCode(typeName));
            gridItems.Add(CreateColorInputVariants(nonNullableState));

            var nonNullableAnyState = nonNullableState as IAnyState;
            object? nonNullableValue = null;
            if (nonNullableAnyState != null)
            {
                var prop = nonNullableAnyState.GetType().GetProperty("Value");
                nonNullableValue = prop?.GetValue(nonNullableAnyState);
            }

            gridItems.Add(FormatStateValue(typeName, nonNullableValue, false));

            // Nullable columns (next 3)
            gridItems.Add(Text.InlineCode($"{typeName}?"));
            gridItems.Add(CreateColorInputVariants(nullableState));

            var anyState = nullableState as IAnyState;
            object? value = null;
            if (anyState != null)
            {
                var prop = anyState.GetType().GetProperty("Value");
                value = prop?.GetValue(anyState);
            }

            gridItems.Add(FormatStateValue(typeName, value, true));
        }

        return Layout.Grid().Columns(6) | gridItems.ToArray();
    }

    private static object CreateColorInputVariants(object state)
    {
        if (state is not IAnyState anyState)
            return Text.Block("Not an IAnyState");

        var stateType = anyState.GetStateType();
        var isNullable = stateType.IsNullableType();

        if (isNullable)
        {
            // For nullable states, show basic variant
            return anyState.ToColorInput();
        }

        // For non-nullable states, show all variants
        return Layout.Vertical()
               | anyState.ToColorInput()
               | anyState.ToColorInput().Placeholder("Select color")
               | anyState.ToColorInput().Disabled();
    }

    private static object FormatStateValue(string typeName, object? value, bool isNullable)
    {
        return value switch
        {
            null => isNullable ? Text.InlineCode("Null") : Text.InlineCode("Default"),
            string s => Text.InlineCode(s),
            Colors c => Text.InlineCode(c.ToString()),
            _ => Text.InlineCode(value?.ToString() ?? "null")
        };
    }

    private static string ConvertToHex(string? colorValue)
    {
        if (string.IsNullOrEmpty(colorValue))
            return "null";

        // Simple conversion for demo purposes
        // In a real implementation, you'd want proper color parsing
        return colorValue.StartsWith("#") ? colorValue : $"#{colorValue.GetHashCode():X6}";
    }
}