using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.ViewModels.Weather;

namespace Thermometer.Infrastructure
{
    internal class CurrentWeatherManager : ICurrentWeatherManager
    {
        #region Fields

        private readonly IViewModelProvider _viewModelProvider;

        #endregion

        #region Constructors

        public CurrentWeatherManager(IViewModelProvider viewModelProvider)
        {
            _viewModelProvider = viewModelProvider;
        }

        #endregion

        #region Methods

        public async Task ShowSensorHistoryAsync(int idSensor, IViewModel parentViewModel)
        {
            using (var vm = _viewModelProvider.GetViewModel<SensorHistoryVm>(parentViewModel, parameters: Constants.IdSensor.ToValue(idSensor)))
            {
                await vm.ShowAsync();
            }
        }

        #endregion
    }
}