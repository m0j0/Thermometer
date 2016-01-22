using MugenMvvmToolkit.Models;

namespace Thermometer.Models
{
    public class SettingsModel : NotifyPropertyChangedBase
    {
        public bool LocationConsent { get; set; }

        public int DeviceRadius { get; set; }

        public SettingsModel Clone()
        {
            return new SettingsModel {LocationConsent = LocationConsent, DeviceRadius = DeviceRadius};
        }
    }
}