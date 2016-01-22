using System;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class WeatherForecastVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentLocationDataProvider _currentLocationDataProvider;

        #endregion

        #region Constructors

        public WeatherForecastVm(ICurrentLocationDataProvider currentLocationDataProvider)
        {
            _currentLocationDataProvider = currentLocationDataProvider;
        }

        #endregion
        
        #region Properties

        public string DisplayName { get; set; }

        public LocationProjection Location { get; set; }

        #endregion

        #region Methods

        //public void Initialize(DateTime date)
        protected override void OnInitialized()
        {
            //DisplayName = date.ToString("M");
            DisplayName = DateTime.Now.ToString("M");
            _currentLocationDataProvider.GetCurrentUserLocationAsync().ContinueWith(task => Location = task.Result).WithBusyIndicator(this);
        }

        #endregion
    }
}