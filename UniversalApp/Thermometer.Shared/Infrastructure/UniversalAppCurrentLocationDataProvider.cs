using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    public class UniversalAppCurrentLocationDataProvider : ICurrentLocationDataProvider
    {
        public async Task<LocationProjection> GetCurrentUserLocationAsync()
        {
            var geolocator = new Geolocator();

            var geoposition = await geolocator.GetGeopositionAsync();
            
            return new LocationProjection {Latitude = geoposition.Coordinate.Latitude, Longitude = geoposition.Coordinate.Longitude};
        }
    }
}