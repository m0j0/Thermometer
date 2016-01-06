using System.Threading.Tasks;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface ICurrentLocationDataProvider
    {
        Task<LocationProjection> GetCurrentUserLocationAsync();
    }
}