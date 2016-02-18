using System.Threading.Tasks;

namespace Thermometer.Interfaces
{
    public interface IWeatherForecastDataProvider
    {
        Task<string> GetForecastByCityIdAsync(int idCity);
    }
}
