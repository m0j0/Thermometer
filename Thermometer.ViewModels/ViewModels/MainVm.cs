using System;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;
using Thermometer.ViewModels.Common;
using Thermometer.ViewModels.Weather;

namespace Thermometer.ViewModels
{
    public class MainVm : MultiViewModel
    {
        #region Fields

        #endregion

        #region Constructors

        public MainVm()
        {
            OpenSettingsCommand = new RelayCommand(OpenSettings);
        }

        #endregion

        #region Commands

        public ICommand OpenSettingsCommand { get; }

        private async void OpenSettings()
        {
            using (var vm = GetViewModel<SettingsVm>())
            using (var wrapper = vm.Wrap<IEditorWrapperVm>())
            {
                await wrapper.ShowAsync();
            }
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddViewModel(GetViewModel<WeatherForecastVm>());
            AddViewModel(GetViewModel<WeatherForecastVm>());

            var sensorHistoryVm = GetViewModel<SensorHistoryVm>();
            sensorHistoryVm.Initialize(new SensorProjection
            {
                Id = 4638,
                Type = 1,
                Name = "Температура",
                Value = -23.3F,
                Unit = "*",
                Time = DateTime.Now
            });
            AddViewModel(sensorHistoryVm);
            AddViewModel(GetViewModel<CurrentWeatherVm>());
        }
        
        #endregion
    }
}