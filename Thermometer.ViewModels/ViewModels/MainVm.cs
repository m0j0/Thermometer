using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;

namespace Thermometer.ViewModels
{
    public class MainVm : CloseableViewModel
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;
        private string _text = "Hello MugenMvvmToolkit 1";

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
            _currentWeatherDataProvider.GetInfoAsync().ContinueWith(task => Text = task.Result);
        }

        #endregion


        #region Properties

        public string Text
        {
            get { return _text; }
            set
            {
                if (Equals(_text, value))
                    return;
                _text = value;
                OnPropertyChanged();
            }
        }

        public IList<string> Items { get; }

        #endregion
    }
}