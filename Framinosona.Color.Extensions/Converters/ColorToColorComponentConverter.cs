using System;
using System.Globalization;
using Xamarin.Forms;

namespace Framinosona.Color.Extensions.Converters
{
    public class ColorToCyanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.GetCyan() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Xamarin.Forms.Color baseColor ? baseColor.WithCyan(input) : Xamarin.Forms.Color.Black;
        }
    }

    public class ColorToMagentaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.GetMagenta() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Xamarin.Forms.Color baseColor ? baseColor.WithMagenta(input) : Xamarin.Forms.Color.Black;
        }
    }

    public class ColorToYellowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.GetYellow() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double input && parameter is Xamarin.Forms.Color baseColor ? baseColor.WithYellow(input) : Xamarin.Forms.Color.Black;
        }
    }

    public class ColorToBlackKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.GetBlackKey() : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Xamarin.Forms.Color.Black;
        }
    }
}