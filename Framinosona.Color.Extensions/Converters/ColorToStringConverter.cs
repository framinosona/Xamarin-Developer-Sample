using System;
using System.Globalization;
using Xamarin.Forms;

namespace Framinosona.Color.Extensions.Converters
{
    public abstract class BaseColorToStringConverter : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToRgbStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToRgbString() : "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToRgbaStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToRgbaString() : "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToHexRgbStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToHexRgbString() : "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToHexRgbaStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToHexRgbaString() : "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToCmyStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToCmyString() : "";
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(string))]
    public class ColorToCmykStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToCmykString() : "";
        }
    }
}