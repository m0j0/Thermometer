using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class CurrentWeatherVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;
        private readonly ISensorPinManager _sensorPinManager;
        private readonly ICurrentWeatherManager _currentWeatherManager;

        #endregion

        #region Constructors

        public CurrentWeatherVm(ICurrentWeatherDataProvider currentWeatherDataProvider, ISensorPinManager sensorPinManager, ICurrentWeatherManager currentWeatherManager)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            _sensorPinManager = sensorPinManager;
            _currentWeatherManager = currentWeatherManager;

            ShowSensorCommand = new RelayCommand<SensorProjection>(ShowSensor, CanShowSensor, this);
            ChangeSensorPinStatusCommand = new RelayCommand<SensorProjection>(ChangeSensorPinStatus, CanChangeSensorPinStatus, this);
        }

        #endregion

        #region Commands

        public ICommand ShowSensorCommand { get; }

        private void ShowSensor(SensorProjection projection)
        {
            _currentWeatherManager.ShowSensorHistoryAsync(projection.Id, this);
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
