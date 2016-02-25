using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;

namespace Thermometer.Modules
{
    public class ViewModelModule : ModuleBase
    {
        #region Constructors

        public ViewModelModule() : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Methods

        protected override bool LoadInternal()
        {
            IocContainer.Bind<ICurrentWeatherManager, CurrentWeatherManager>(DependencyLifecycle.SingleInstance);

            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}