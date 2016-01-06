using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

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

            AddViewModel(GetViewModel<CurrentWeatherVm>());
            AddViewModel(GetViewModel<WeatherForecastVm>());
            AddViewModel(GetViewModel<WeatherForecastVm>());
            AddViewModel(GetViewModel<SensorHistoryVm>());
        }

        #endregion
    }
}