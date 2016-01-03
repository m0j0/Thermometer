using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface ICurrentWeatherDataProvider
    {
        Task<IList<DeviceProjection>> GetDevicesAsync();
    }
}
