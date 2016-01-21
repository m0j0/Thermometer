using System;
using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels
{
    public class CurrentWeatherVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;

        #endregion

        #region Constructors

        public CurrentWeatherVm(ICurrentWeatherDataProvider currentWeatherDataProvider)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;

            _currentWeatherDataProvider.GetDevicesAsync().ContinueWith(task => Items = task.Result).WithBusyIndicator(this);

            ShowSensorCommand = new RelayCommand<SensorProjection>(ShowSensor, CanShowSensor, this);
        }

        #endregion

        #region Commands

        public ICommand ShowSensorCommand { get; }

        private async void ShowSensor(SensorProjection projection)
        {
            using (var vm = GetViewModel<SensorHistoryVm>())
            using (var wrapper = vm.Wrap<IDisplayWrapperVm>())
            {
                vm.Initialize(projection);
                await wrapper.ShowAsync();
            }
        }

        private bool CanShowSensor(SensorProjection projection)
        {
            return projection != null;
        }

        #endregion

        #region Properties

        public string Text { get; set; } = "Hello MugenMvvmToolkit 1";

        public string DisplayName { get; set; } = "Сейчас";

        public IList<DeviceProjection> Items { get; private set; }

        #endregion
    }
}
