﻿namespace Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using SolutionControls;

    /// <summary>
    /// Represents a converter from status types to a theme foreground brush.
    /// </summary>
    public class StatusTypesToThemeForegroundBrushConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts from status types to a theme foreground brush.
        /// </summary>
        /// <param name="values">The array of values to convert.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length >= 2)
            {
                if (values[0] == DependencyProperty.UnsetValue)
                    return null!;

                if ((values[0] is StatusType StatusType) && (values[1] is IStatusTheme Theme))
                    return Theme.GetForegroundBrush(StatusType);
            }

            throw new ArgumentOutOfRangeException(nameof(values));
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to.</param>
        /// <param name="parameter">The converter parameter to use..</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>The converted value.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return Array.Empty<object>();
        }
    }
}
