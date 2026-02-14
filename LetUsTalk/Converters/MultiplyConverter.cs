using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace LetUsTalk.Converters;

public sealed class MultiplyConverter : IValueConverter
{
    public static readonly MultiplyConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double number && parameter is not null)
        {
            string[] parts = parameter.ToString()!.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length >= 1 &&
                double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double factor))
            {
                double result = number * factor;
                if (parts.Length >= 2 &&
                    double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double min))
                {
                    return Math.Max(result, min);
                }

                return result;
            }
        }

        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
