using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace LetUsTalk.UI.Converters;

public sealed class MultiplyConverter : IValueConverter
{
    public static readonly MultiplyConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        object? result = value;

        if (value is double number && parameter is not null)
        {
            string[] parts = parameter.ToString()!
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length == 1 && double.TryParse(parts[0], out double factor))
            {
                result = number * factor;
            }
        }

        return result;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
