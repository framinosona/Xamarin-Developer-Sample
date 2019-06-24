using System;
using System.Globalization;
using DeveloperSample.Core.Helpers;
using Xamarin.Forms;

namespace DeveloperSample.Core.Converters
{
    public abstract class BaseColorToStringConverter : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToRgbStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToRgbString() : "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToRgbaStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToRgbaString() : "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToHexRgbStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToHexRgbString() : "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToHexRgbaStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToHexRgbaString() : "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToCmyStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToCmyString() : "";
        }
    }

    [ValueConversion(typeof(Color), typeof(string))]
    public class ColorToCmykStringConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToCmykString() : "";
        }
    }
}