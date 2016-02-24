using MugenMvvmToolkit;
using MugenMvvmToolkit.Binding;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.Models.IoC;
using MugenMvvmToolkit.Modules;
using Thermometer.Extensions;
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
            IocContainer.Bind<ISensorPinManager, SensorPinManager>(DependencyLifecycle.SingleInstance);
            IocContainer.Bind<IMd5AlgorithmProvider, Md5AlgorithmProvider>(DependencyLifecycle.SingleInstance);
            BindingServiceProvider.ResourceResolver.AddType("ModelExtensions", typeof(ModelExtensions));
            return true;
        }

        protected override void UnloadInternal()
        {
        }
    }
}