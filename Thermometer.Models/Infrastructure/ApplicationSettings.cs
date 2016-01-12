using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class ApplicationSettings : IApplicationSettings
    {
        public bool LocationConsent => true;

        public int Radius => 20;

        public LocationProjection DefaultLocation => new LocationProjection(92.8805, 56.029);
    }
}