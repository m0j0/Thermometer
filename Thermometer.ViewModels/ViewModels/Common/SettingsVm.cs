using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Models;

namespace Thermometer.ViewModels.Common
{
    public class SettingsVm : EditableViewModel<SettingsModel>, IHasDisplayName
    {
        #region Properties

        public string DisplayName { get; set; } = "Настройки";

        public bool LocationConsent
        {
            get { return Entity.LocationConsent; }
            set { Entity.LocationConsent = value; }
        }

        public int DeviceRadius
        {
            get { return Entity.DeviceRadius; }
            set { Entity.DeviceRadius = value; }
        }

        #endregion
    }
}