using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;

namespace Thermometer.Modules
{
    public class UniversalAppModule : ModuleBase
    {
        public UniversalAppModule() : base(false, LoadMode.All)
        {
        }

        protected override bool LoadInternal()
        {
            IocContainer.Bind<ICurrentLocationDataProvider, UniversalAppCurrentLocationDataProvider>(DependencyLifecycle.SingleInstance);
            IocContainer.Bind<IApplicationSettings, Infrastructure.ApplicationSettings>(DependencyLifecycle.SingleInstance);
            return true;
        }

        protected override void UnloadInternal()
        {
        }
    }
}