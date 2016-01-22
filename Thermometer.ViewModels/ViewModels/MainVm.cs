using System;
using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;
using Thermometer.ViewModels.Common;

namespace Thermometer.ViewModels
{
    public class MainVm : MultiViewModel
    {
        #region Fields

        #endregion

        #region Constructors

        public MainVm()
        {
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
            AddViewModel(GetViewModel<SettingsVm>());
        }

        #endregion
    }
}