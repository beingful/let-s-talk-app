using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace LetUsTalk.UI.Converters;

public sealed class ConditionalMultiplyConverter : IMultiValueConverter
{
    public static ConditionalMultiplyConverter Instance { get; } = new();

    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        object? result = BindingOperations.DoNothing;

        if (values.Any(value => value is UnsetValueType) == false)
        {
            string[]? parameters = parameter
                ?.ToString()
                ?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parameters?.Length >= 1 && values[1] is bool condition)
            {
                if (condition == false)
                {
                    result = 0d;
                }
                else if (values[0] is double number)
                {
                    if (parameters.Length == 1)
                    {
                        result = MultiplyConverter.Instance.Convert(number, targetType, parameter, culture);
                    }
                    else
                    {
                        result = LimitedMultiplyConverter.Instance.Convert(number, targetType, parameter, culture);
                    }
                }
            }
        }

        return result;
    }
}
