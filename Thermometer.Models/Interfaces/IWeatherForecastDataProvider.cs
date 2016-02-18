using System.Collections.Generic;
using System.Threading.Tasks;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface IWeatherForecastDataProvider
    {
        Task<IList<WeatherForecastProjection>> GetForecastByCityIdAsync(int idCity);
    }
}
