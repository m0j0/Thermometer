using System;
using Windows.UI.Xaml.Data;
using Thermometer.Infrastructure;

namespace Thermometer.Converters
{
    internal class SensorHistoryPeriodTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var t = (SensorHistoryPeriod) value;
            var p = (SensorHistoryPeriod) parameter;
            return t == p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return parameter;
        }
    }
}