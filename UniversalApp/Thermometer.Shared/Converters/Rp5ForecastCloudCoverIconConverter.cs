using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;
using Thermometer.Infrastructure;

namespace Thermometer.Converters
{
    public class Rp5ForecastCloudCoverIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var icon = (Rp5ForecastCloudCoverIcon) value;
            BitmapImage bi = new BitmapImage();
            switch (icon)
            {
                case Rp5ForecastCloudCoverIcon.DayIcon1:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_1.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon2:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_2.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon3:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_3.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon4:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_4.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon5:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_5.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon6:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_6.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon7:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_7.png");
                    break;
                case Rp5ForecastCloudCoverIcon.DayIcon8:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_day_8.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon1:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_1.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon2:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_2.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon3:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_3.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon4:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_4.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon5:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_5.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon6:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_6.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon7:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_7.png");
                    break;
                case Rp5ForecastCloudCoverIcon.NightIcon8:
                    bi.UriSource = new Uri("ms-appx:///Assets/Rp5Icons/ic_forecast_cloud_cover_night_8.png");
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
