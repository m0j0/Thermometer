using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class FakeCurrentWeatherDataProvider : ICurrentWeatherDataProvider
    {
        public Task<IList<DeviceProjection>> GetDevicesAsync()
        {
            var result = new List<DeviceProjection>();
            for (var i = 0; i < 5; i++)
            {
                var device = new DeviceProjection
                {
                    Id = i,
                    Name = $"Название {i}",
                    Location = $"Положение {i}",
                    Distance = i*5,
                    Latitude = 1,
                    Longitude = 1,
                    Sensors = new List<SensorProjection>()
                };
                for (var j = 0; j < 3; j++)
                {
                    device.Sensors.Add(new SensorProjection
                    {
                        Id = i + j,
                        Type = 1,
                        Name = $"Название {j}",
                        Value = j,
                        Unit = " гр",
                        Time = DateTime.Now
                    });
                }

                result.Add(device);
            }

            return Task.FromResult<IList<DeviceProjection>>(result);
        }
    }
}
