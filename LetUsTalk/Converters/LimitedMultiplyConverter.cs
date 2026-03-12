using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace LetUsTalk.UI.Converters;

public sealed class LimitedMultiplyConverter : IValueConverter
{
    public static readonly LimitedMultiplyConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        object? result = value;

        if (value is double && parameter is not null)
        {
            string[] parameters = parameter.ToString()!
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parameters.Length == 3 && double.TryParse(parameters[0], out double factor))
            {
                double? convertedNumber = MultiplyConverter.Instance.Convert(value, targetType, factor, culture) as double?;

                if (convertedNumber.HasValue &&
                    double.TryParse(parameters[1], out double min) &&
                    double.TryParse(parameters[2], out double max))
                {
                    if (min > 0)
                    {
                        convertedNumber = Math.Max(convertedNumber.Value, min);
                    }
                    if (max > 0)
                    {
                        convertedNumber = Math.Min(convertedNumber.Value, max);
                    }

                    result = convertedNumber;
                }
            }
        }

        return result;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
