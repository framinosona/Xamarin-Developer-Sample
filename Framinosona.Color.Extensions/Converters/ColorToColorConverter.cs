using System;
using System.Globalization;
using Xamarin.Forms;

namespace Framinosona.Color.Extensions.Converters
{
    public abstract class BaseColorToColorConverter : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(Xamarin.Forms.Color))]
    public class ColorToBlackOrWhiteConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToBlackOrWhite() : Xamarin.Forms.Color.Black;
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(Xamarin.Forms.Color))]
    public class ColorToColorForTextConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToBlackOrWhiteForText() : Xamarin.Forms.Color.Black;
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(Xamarin.Forms.Color))]
    public class ColorToGrayScaleColorConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.ToGrayScale() : Xamarin.Forms.Color.Black;
        }
    }

    [ValueConversion(typeof(Xamarin.Forms.Color), typeof(Xamarin.Forms.Color))]
    public class ColorToInverseColorConverter : BaseColorToColorConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Xamarin.Forms.Color input ? input.Inverse() : Xamarin.Forms.Color.Black;
        }
    }
}