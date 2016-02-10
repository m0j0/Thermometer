using System.Threading.Tasks;

namespace Thermometer.Interfaces
{
    public interface ISensorPinManager
    {
        Task ChangePinStatusAsync(int idSensor);

        bool IsSensorPinned(int idSensor);
    }
}