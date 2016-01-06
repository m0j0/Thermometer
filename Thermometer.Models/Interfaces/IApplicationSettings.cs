using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface IApplicationSettings
    {
        bool LocationConsent { get; }

        int Radius { get; }

        LocationProjection DefaultLocation { get; }
    }
}