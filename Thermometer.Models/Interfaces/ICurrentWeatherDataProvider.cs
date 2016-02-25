using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thermometer.Infrastructure;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface ICurrentWeatherDataProvider
    {
        Task<IList<DeviceProjection>> GetDevicesAsync();

        Task<IList<SensorHistoryData>> UpdateSensorHistoryAsync(int idSensor, SensorHistoryPeriod period, DateTime offset);
    }
}