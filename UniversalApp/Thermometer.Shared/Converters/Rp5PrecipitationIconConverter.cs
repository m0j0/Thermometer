using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Thermometer.Infrastructure;

namespace Thermometer.Converters
{
    internal class Rp5PrecipitationIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var icon = (Rp5PrecipitationIcon)value;
            BitmapImage bi = new BitmapImage();
            switch (icon)
            {
                case Rp5PrecipitationIcon.Rain1:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_1.png");
                    break;
                case Rp5PrecipitationIcon.Rain2:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_2.png");
                    break;
                case Rp5PrecipitationIcon.Rain3:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_3.png");
                    break;
                case Rp5PrecipitationIcon.Rain4:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_4.png");
                    break;
                case Rp5PrecipitationIcon.Rain5:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_5.png");
                    break;
                case Rp5PrecipitationIcon.RainAndSnow1:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_and_snow_1.png");
                    break;
                case Rp5PrecipitationIcon.RainAndSnow2:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_and_snow_2.png");
                    break;
                case Rp5PrecipitationIcon.RainAndSnow3:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_and_snow_3.png");
                    break;
                case Rp5PrecipitationIcon.RainAndSnow4:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_and_snow_1.png");
                    break;
                case Rp5PrecipitationIcon.RainAndSnow5:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_rain_and_snow_1.png");
                    break;
                case Rp5PrecipitationIcon.Snow1:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_snow_1.png");
                    break;
                case Rp5PrecipitationIcon.Snow2:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_snow_2.png");
                    break;
                case Rp5PrecipitationIcon.Snow3:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_snow_3.png");
                    break;
                case Rp5PrecipitationIcon.Snow4:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_snow_4.png");
                    break;
                case Rp5PrecipitationIcon.Snow5:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_snow_5.png");
                    break;
                default:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_no_precipitation.png");
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