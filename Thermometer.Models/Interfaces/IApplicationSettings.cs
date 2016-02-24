using Thermometer.Infrastructure;
using Thermometer.Models;
using Thermometer.Projections;

namespace Thermometer.Interfaces
{
    public interface IApplicationSettings
    {
        TemperatureMeasureUnit TemperatureMeasureUnit { get; }

        PressureMeasureUnit PressureMeasureUnit { get; }

        WindMeasureUnit WindMeasureUnit { get; }

        CloudinessMeasureUnit CloudinessMeasureUnit { get; }

        PrecipitationMeasureUnit PrecipitationMeasureUnit { get; }

        bool LocationConsent { get; }

        int DeviceRadius { get; }

        LocationProjection DefaultLocation { get; }

        SettingsModel GetApplicationSettings();

        void UpdateSettings(SettingsModel settings);
    }
}