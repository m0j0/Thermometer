using System;
using System.Collections.Generic;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class WeatherForecastVm : CloseableViewModel, IHasDisplayName
    {
        #region Properties

        public string DisplayName { get; set; }

        public IList<WeatherForecastProjection> Items { get; private set; }

        #endregion

        #region Methods
        
        public void Initialize(DateTime dateTime, IList<WeatherForecastProjection> forecastItems)
        {
            if (dateTime.Date == DateTime.Today)
            {
                DisplayName = "Сегодня";
            }
            else if (dateTime.Date == DateTime.Today.AddDays(1))
            {
                DisplayName = "Завтра";
            }
            else
            {
                DisplayName = dateTime.ToString("dddd");
            }
            
            Items = forecastItems;
        }

        #endregion
    }
}