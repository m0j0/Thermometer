using System;
using System.Collections.Generic;
using System.Linq;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer.Extensions
{
    public static class NarodMonExtensions
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
                                    Time = ModelExtensions.UnixTimeStampToDateTime(sensor.Time, true),
#if DEBUG
                                    IsPinned = new Random().Next() % 2 == 1
#endif
                                }).ToList()
                };
                result.Add(projection);
            }
            return result;
        }

        #endregion
    }
}