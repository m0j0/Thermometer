using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Thermometer.Infrastructure;

namespace Thermometer.Converters
{
    internal class Rp5WindDirectionForecastIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var windDirection = (WindDirection) value;
            var bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri($"ms-appx:///Assets/Rp5Icons/ic_forecast_wind_{windDirection.ToString().ToLower()}.png");
            return bitmapImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}