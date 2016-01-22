using Windows.Storage;
using Thermometer.Interfaces;
using Thermometer.Models;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class ApplicationSettings : IApplicationSettings
    {
        #region Fields

        private readonly SettingsModel _settings;

        #endregion

        #region Constructors

        public ApplicationSettings()
        {
            var roamingSettings = ApplicationData.Current.RoamingSettings;
            _settings = new SettingsModel
            {
                LocationConsent = roamingSettings.Values[nameof(LocationConsent)] as bool? ?? false,
                DeviceRadius = roamingSettings.Values[nameof(DeviceRadius)] as int? ?? 10
            };
        }

        #endregion

        #region Implementation

        public bool LocationConsent => _settings.LocationConsent;

        public int DeviceRadius => _settings.DeviceRadius;

        public LocationProjection DefaultLocation => new LocationProjection(92.8805, 56.029);

        public SettingsModel GetApplicationSettings()
        {
            return _settings.Clone();
        }

        public void UpdateSettings(SettingsModel settings)
        {
            var roamingSettings = ApplicationData.Current.RoamingSettings;
            roamingSettings.Values[nameof(LocationConsent)] = _settings.LocationConsent = settings.LocationConsent;
            roamingSettings.Values[nameof(DeviceRadius)] = _settings.DeviceRadius = settings.DeviceRadius;
        }

        #endregion
    }
}