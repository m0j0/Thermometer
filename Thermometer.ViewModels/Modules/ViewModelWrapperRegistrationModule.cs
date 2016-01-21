using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Modules;
using Thermometer.Interfaces;
using Thermometer.ViewModels.Wrappers;

namespace Thermometer.Modules
{
    public class ViewModelWrapperRegistrationModule : WrapperRegistrationModuleBase
    {
        #region Overrides of WrapperRegistrationModuleBase

        protected override void RegisterWrappers(IConfigurableWrapperManager wrapperManager)
        {
            wrapperManager.AddWrapper<IDisplayWrapperVm, DisplayWrapperVm>();
        }

        #endregion
    }
}