using System;
using System.Collections.Generic;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class WeatherForecastVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly IWeatherForecastDataProvider _weatherForecastDataProvider;

        #endregion

        #region Constructors

        public WeatherForecastVm(IWeatherForecastDataProvider weatherForecastDataProvider)
        {
            _weatherForecastDataProvider = weatherForecastDataProvider;
        }

        #endregion
        
        #region Properties

        public string DisplayName { get; set; }

        public string Location { get; set; }

        public IList<WeatherForecastProjection> Items { get; private set; }

        #endregion

        #region Methods

        //public void Initialize(DateTime date)
        protected override void OnInitialized()
        {
            //DisplayName = date.ToString("M");
            DisplayName = DateTime.Now.ToString("M");
            _weatherForecastDataProvider.GetForecastByCityIdAsync(4475).ContinueWith(task => Items = task.Result).WithBusyIndicator(this);
        }

        #endregion
    }
}