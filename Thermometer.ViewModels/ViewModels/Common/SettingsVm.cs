using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Models;

namespace Thermometer.ViewModels.Common
{
    public class SettingsVm : EditableViewModel<SettingsModel>
    {
        #region Fields

        private readonly IApplicationSettings _applicationSettings;

        #endregion

        #region Constructors

        public SettingsVm(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        #endregion

        #region Properties

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