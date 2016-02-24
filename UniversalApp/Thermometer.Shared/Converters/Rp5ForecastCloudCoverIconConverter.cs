using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Thermometer.Extensions;
using Thermometer.Projections;

namespace Thermometer.Converters
{
    internal class Rp5ForecastCloudCoverIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var weatherForecastProjection = (WeatherForecastProjection) value;
            var forecastCloudCoverIconNumber = Rp5Extensions.GetForecastCloudCoverIconNumber(weatherForecastProjection.Cloudiness.Percents);
            var text = Rp5Extensions.IsDayForecast(weatherForecastProjection) ? "day" : "night";
            var bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri($"ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_{text}_{forecastCloudCoverIconNumber}.png");
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}