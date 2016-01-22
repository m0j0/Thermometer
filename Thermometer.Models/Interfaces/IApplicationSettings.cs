using Thermometer.Models;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface IApplicationSettings
    {
        bool LocationConsent { get; }

        int DeviceRadius { get; }

        LocationProjection DefaultLocation { get; }

        SettingsModel GetApplicationSettings();

        void UpdateSettings(SettingsModel settings);
    }
}