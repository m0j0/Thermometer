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
                                    Time = UnixTimeStampToDateTime(sensor.Time)
                                }).ToList()
                };
                result.Add(projection);
            }
            return result;
        }

        #endregion

        #region Public methods

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
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

        #endregion
    }
}