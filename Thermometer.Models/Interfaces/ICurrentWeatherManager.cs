using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.ViewModels;

namespace Thermometer.Interfaces
{
    public interface ICurrentWeatherManager
    {
        Task ShowSensorHistoryAsync(int idSensor, IViewModel parentViewModel);
    }
}