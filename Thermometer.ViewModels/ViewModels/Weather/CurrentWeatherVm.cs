using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class CurrentWeatherVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;
        private readonly ISensorPinManager _sensorPinManager;

        #endregion

        #region Constructors

        public CurrentWeatherVm(ICurrentWeatherDataProvider currentWeatherDataProvider, ISensorPinManager sensorPinManager)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            _sensorPinManager = sensorPinManager;

            ShowSensorCommand = new RelayCommand<SensorProjection>(ShowSensor, CanShowSensor, this);
            ChangeSensorPinStatusCommand = new RelayCommand<SensorProjection>(ChangeSensorPinStatus, CanChangeSensorPinStatus, this);
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

        public ICommand ChangeSensorPinStatusCommand { get; }

        private void ChangeSensorPinStatus(SensorProjection projection)
        {
            _sensorPinManager.ChangePinStatusAsync(projection.Id);
        }

        private bool CanChangeSensorPinStatus(SensorProjection projection)
        {
            return _sensorPinManager != null && projection != null;
        }

        #endregion

        #region Properties

        public string DisplayName { get; set; } = "Сейчас";

        public IList<DeviceProjection> Items { get; private set; }

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _currentWeatherDataProvider.GetDevicesAsync().ContinueWith(task => Items = task.Result).WithBusyIndicator(this);
        }

        #endregion
    }
}
