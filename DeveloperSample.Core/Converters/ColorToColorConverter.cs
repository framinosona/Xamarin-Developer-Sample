using System;
using System.Globalization;
using DeveloperSample.Core.Helpers;
using Xamarin.Forms;

namespace DeveloperSample.Core.Converters
{
    public abstract class BaseColorToColorConverter : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(Color), typeof(Color))]
    public class ColorToBlackOrWhiteConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToBlackOrWhite() : Color.Black;
        }
    }

    [ValueConversion(typeof(Color), typeof(Color))]
    public class ColorToColorForTextConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToBlackOrWhiteForText() : Color.Black;
        }
    }

    [ValueConversion(typeof(Color), typeof(Color))]
    public class ColorToGrayScaleColorConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.ToGrayScale() : Color.Black;
        }
    }

    [ValueConversion(typeof(Color), typeof(Color))]
    public class ColorToInverseColorConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color input ? input.Inverse() : Color.Black;
        }
    }
}