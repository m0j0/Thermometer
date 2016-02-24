using System;
using Windows.UI.Xaml.Data;
using MugenMvvmToolkit;
using Thermometer.Extensions;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Converters
{
    internal class CloudinessTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mu = ServiceProvider.Get<IApplicationSettings>().CloudinessMeasureUnit;
            var projection = (CloudinessProjection) value;

            string val;
            switch (mu)
            {
                case CloudinessMeasureUnit.Percents:
                    val = projection.Percents.ToString();
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