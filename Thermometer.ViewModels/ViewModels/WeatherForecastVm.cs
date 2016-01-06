using System;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Thermometer.ViewModels
{
    public class WeatherForecastVm : CloseableViewModel, IHasDisplayName
    {
        #region Properties

        public string DisplayName { get; set; }

        #endregion

        #region Methods

        //public void Initialize(DateTime date)
        protected override void OnInitialized()
        {
            //DisplayName = date.ToString("M");
            DisplayName = DateTime.Now.ToString("M");
        }

        #endregion
    }
}