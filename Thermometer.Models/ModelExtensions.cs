using System;
using System.Collections.Generic;
using System.Linq;
using Thermometer.Infrastructure;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer
{
    public static class ModelExtensions
    {
        #region Internal methods

        internal static List<DeviceProjection> ConvertSensorsNearbyResponseToDeviceProjections(SensorsNearbyResponse response)
        {
            var result = new List<DeviceProjection>();
            foreach (var device in response.Devices)
            {
                var projection = new DeviceProjection
                {
                    Id = device.Id,
                    Name = device.Name,
                    Location = device.Location,
                    Distance = device.Distance,
                    Latitude = device.Lat,
                    Longitude = device.Lng,
                    Sensors =
                        device.Sensors.Select(
                            sensor =>
                                new SensorProjection
                                {
                                    Id = sensor.Id,
                                    Type = sensor.Type,
                                    Name = sensor.Name,
                                    Value = sensor.Value,
                                    Unit = sensor.Unit,
                                    Time = UnixTimeStampToDateTime(sensor.Time, true)
                                }).ToList()
                };
                result.Add(projection);
            }
            return result;
        }

        internal static List<WeatherForecastProjection> ConvertToWeatherForecastProjections(Rp5WeatherForecastRootObject deserializeObject)
        {
            var result = new List<WeatherForecastProjection>();
            foreach (var forecastItems in deserializeObject.Response.Forecast.Items)
            {
                foreach (var forecastItem in forecastItems)
                {
                    var forecastDateTime = UnixTimeStampToDateTime(forecastItem.Gmt, false);
                    result.Add(new WeatherForecastProjection
                    {
                        ForecastDateTime = forecastDateTime,
                        Temperature = forecastItem.Temperature.C,
                        FeelTemperature = forecastItem.FeelTemperature.C,
                        Cloudiness = forecastItem.CloudCover.Pct,
                        WindDirection = (Rp5WindDirectionForecast) forecastItem.WindDirection,
                        CloudCoverIcon = GetRp5ForecastCloudCoverIcon(forecastItem.CloudCover.Pct, (forecastDateTime.Hour >= 7) && (forecastDateTime.Hour < 19))
                    });
                }
            }
            return result;
        }

        #endregion

        #region Public methods

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp, bool toLocalTime)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
            return toLocalTime ? dtDateTime.ToLocalTime() : dtDateTime;
        }

        public static string ToText(this SensorHistoryPeriod period)
        {
            switch (period)
            {
                case SensorHistoryPeriod.Day:
                    return "День";
                case SensorHistoryPeriod.Week:
                    return "Неделя";
                case SensorHistoryPeriod.Month:
                    return "Месяц";
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }
        }

        public static string ToText(this Rp5WindDirectionForecast direction)
        {
            switch (direction)
            {
                case Rp5WindDirectionForecast.E:
                    return "В";
                case Rp5WindDirectionForecast.NE:
                    return "С-В";
                case Rp5WindDirectionForecast.N:
                    return "С";
                case Rp5WindDirectionForecast.NW:
                    return "С-З";
                case Rp5WindDirectionForecast.W:
                    return "З";
                case Rp5WindDirectionForecast.SW:
                    return "Ю-З";
                case Rp5WindDirectionForecast.S:
                    return "Ю";
                case Rp5WindDirectionForecast.SE:
                    return "Ю-В";
                case Rp5WindDirectionForecast.Calm:
                    return "ШТЛ";
                default:
                    return String.Empty;
            }
        }

        public static Rp5ForecastCloudCoverIcon GetRp5ForecastCloudCoverIcon(int paramInt, bool isDay)
        {
            if (paramInt >= 100)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon8 : Rp5ForecastCloudCoverIcon.NightIcon8;
            }
            if (paramInt >= 80)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon7 : Rp5ForecastCloudCoverIcon.NightIcon7;
            }
            if (paramInt >= 70)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon6 : Rp5ForecastCloudCoverIcon.NightIcon6;
            }
            if (paramInt >= 50)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon5 : Rp5ForecastCloudCoverIcon.NightIcon5;
            }
            if (paramInt >= 30)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon4 : Rp5ForecastCloudCoverIcon.NightIcon4;
            }
            if (paramInt >= 20)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon3 : Rp5ForecastCloudCoverIcon.NightIcon3;
            }
            if (paramInt > 0)
            {
                return isDay ? Rp5ForecastCloudCoverIcon.DayIcon2 : Rp5ForecastCloudCoverIcon.NightIcon2;
            }
            return isDay ? Rp5ForecastCloudCoverIcon.DayIcon1 : Rp5ForecastCloudCoverIcon.NightIcon1;
        }

        #endregion
    }
}