using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Thermometer.Extensions;
using Thermometer.Infrastructure;
using Thermometer.Projections;

namespace Thermometer.Converters
{
    internal class Rp5PrecipitationIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var weatherForecastProjection = (WeatherForecastProjection) value;
            var bitmapImage = new BitmapImage();
            string text;
            object result;
            switch (weatherForecastProjection.PrecipitationType)
            {
                case PrecipitationType.Rain:
                    text = "rain";
                    break;
                case PrecipitationType.RainAndSnow:
                    text = "rain_and_snow";
                    break;
                case PrecipitationType.Snow:
                    text = "snow";
                    break;
                default:
                    bitmapImage.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_no_precipitation.png");
                    result = bitmapImage;
                    return result;
            }
            bitmapImage.UriSource = new Uri($"ms-appx:///Assets/Rp5Icons/ic_forecast_{text}_{Rp5Extensions.GetPrecipitationIconNumber(weatherForecastProjection.Precipitation.Mm)}.png");
            result = bitmapImage;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}