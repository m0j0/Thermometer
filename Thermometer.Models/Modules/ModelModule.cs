using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;

namespace Thermometer.Modules
{
    public class ModelModule : ModuleBase
    {
        #region Constructors

        public ModelModule() : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Methods

        protected override bool LoadInternal()
        {
#if DEBUG
            IocContainer.Bind<ICurrentWeatherDataProvider, FakeCurrentWeatherDataProvider>(DependencyLifecycle.SingleInstance);
            //IocContainer.Bind<ICurrentWeatherDataProvider, NarodMonWeatherDataProvider>(DependencyLifecycle.SingleInstance);
#else
            IocContainer.Bind<ICurrentWeatherDataProvider, NarodMonWeatherDataProvider>(DependencyLifecycle.SingleInstance);
#endif

            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}