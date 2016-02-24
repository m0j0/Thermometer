using System;
using Windows.UI.Xaml.Data;
using MugenMvvmToolkit;
using Thermometer.Extensions;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Converters
{
    internal class WindTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mu = ServiceProvider.Get<IApplicationSettings>().WindMeasureUnit;
            var projection = (WeatherForecastProjection) value;

            string val;
            switch (mu)
            {
                case WindMeasureUnit.Ms:
                    val = projection.WindSpeed.Ms.ToString();
                    break;
                case WindMeasureUnit.Kmh:
                    val = projection.WindSpeed.Kmh.ToString();
                    break;
                case WindMeasureUnit.Mph:
                    val = projection.WindSpeed.Mph.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return $"{val} {mu.GetMeasureUnitAbbreviation()}, {projection.WindDirection.ToText()}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}