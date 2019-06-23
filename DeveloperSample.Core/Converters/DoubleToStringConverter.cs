using System;
using System.Globalization;
using Xamarin.Forms;


namespace DeveloperSample.Core.Converters
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double input))
            {
                return default(string);
            }
            var decimals = 2;
            if (parameter is int decimalsparam)
                decimals = decimalsparam;


            return Math.Round(input, decimals);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}