using System;
using Windows.UI.Xaml.Data;

namespace Thermometer.Converters
{
    internal class DateTimeToShortTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime) value).ToString("t");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}