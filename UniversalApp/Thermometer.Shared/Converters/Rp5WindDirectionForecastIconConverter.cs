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
            var icon = (Rp5WindDirectionForecast) value;
            var bi = new BitmapImage();
            switch (icon)
            {
                case Rp5WindDirectionForecast.E:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_e.png");
                    break;
                case Rp5WindDirectionForecast.NE:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_ne.png");
                    break;
                case Rp5WindDirectionForecast.N:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_n.png");
                    break;
                case Rp5WindDirectionForecast.NW:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_nw.png");
                    break;
                case Rp5WindDirectionForecast.W:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_w.png");
                    break;
                case Rp5WindDirectionForecast.SW:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_sw.png");
                    break;
                case Rp5WindDirectionForecast.S:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_s.png");
                    break;
                case Rp5WindDirectionForecast.SE:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_se.png");
                    break;
                case Rp5WindDirectionForecast.Calm:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_wind_calm.png");
                    break;
            }
            return bi;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}