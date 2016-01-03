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

        public ModelModule()
            : base(false, LoadMode.All)
        {
        }

        #endregion

        #region Methods

        protected override bool LoadInternal()
        {
            IocContainer.Bind<ICurrentWeatherDataProvider, NarodMonWeatherDataProvider>(
                DependencyLifecycle.SingleInstance);

            return true;
        }

        protected override void UnloadInternal()
        {
        }

        #endregion
    }
}