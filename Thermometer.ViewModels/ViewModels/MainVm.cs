using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;

namespace Thermometer.ViewModels
{
    public class MainVm : CloseableViewModel
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;

        #endregion

        #region Constructors

        public MainVm(ICurrentWeatherDataProvider currentWeatherDataProvider)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            Items = new List<string>();
            for (var i = 0; i < 100; i++)
            {
                Items.Add($"item{i}");
            }
            _currentWeatherDataProvider.GetInfoAsync().ContinueWith(task => Text = task.Result).WithBusyIndicator(this);
        }

        #endregion


        #region Properties

        public string Text { get; set; } = "Hello MugenMvvmToolkit 1";

        public IList<string> Items { get; }

        #endregion
    }
}