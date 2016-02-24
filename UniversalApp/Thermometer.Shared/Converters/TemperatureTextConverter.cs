using System;
using Windows.UI.Xaml.Data;
using MugenMvvmToolkit;
using Thermometer.Extensions;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Converters
{
    internal class TemperatureTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mu = ServiceProvider.Get<IApplicationSettings>().TemperatureMeasureUnit;
            var projection = (TemperatureProjection) value;

            string val;
            switch (mu)
            {
                case TemperatureMeasureUnit.Celsius:
                    val = projection.Celsius.ToString();
                    break;

                case TemperatureMeasureUnit.Fahrenheit:
                    val = projection.Fahrenheit.ToString();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            return $"{val} {mu.GetMeasureUnitAbbreviation()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}