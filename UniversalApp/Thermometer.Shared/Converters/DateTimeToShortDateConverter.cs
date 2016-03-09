using System;
using Windows.UI.Xaml.Data;

namespace Thermometer.Converters
{
    internal class DateTimeToShortDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((DateTime) value).ToString("d");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}