using System;
using System.Globalization;
using DeveloperSample.Core.Helpers;
using Xamarin.Forms;

namespace DeveloperSample.Core.Converters
{
    public class ColorToCyanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.GetCyan() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Color baseColor ? baseColor.WithCyan(input) : Color.Black;
        }
    }

    public class ColorToMagentaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.GetMagenta() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Color baseColor ? baseColor.WithMagenta(input) : Color.Black;
        }
    }

    public class ColorToYellowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.GetYellow() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Color baseColor ? baseColor.WithYellow(input) : Color.Black;
        }
    }

    public class ColorToBlackKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.GetBlackKey() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Black;
        }
    }
}