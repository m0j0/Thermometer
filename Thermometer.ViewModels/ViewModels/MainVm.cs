using System.Linq;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Interfaces;
using Thermometer.ViewModels.Common;
using Thermometer.ViewModels.Weather;

namespace Thermometer.ViewModels
{
    public class MainVm : MultiViewModel
    {
        #region Fields

        private readonly IApplicationSettings _applicationSettings;
        private readonly IWeatherForecastDataProvider _weatherForecastDataProvider;

        #endregion

        #region Constructors

        public MainVm(IApplicationSettings applicationSettings, IWeatherForecastDataProvider weatherForecastDataProvider)
        {
            _applicationSettings = applicationSettings;
            _weatherForecastDataProvider = weatherForecastDataProvider;

            OpenSettingsCommand = new RelayCommand(OpenSettings);
            RefreshCommand = new RelayCommand(Refresh);
        }

        #endregion

        #region Commands

        public ICommand OpenSettingsCommand { get; }

        private async void OpenSettings()
        {
            using (var vm = GetViewModel<SettingsVm>())
            using (var wrapper = vm.Wrap<IEditorWrapperVm>())
            {
                vm.InitializeEntity(_applicationSettings.GetApplicationSettings(), false);

                if (!await wrapper.ShowAsync())
                {
                    return;
                }

                _applicationSettings.UpdateSettings(vm.Entity);
            }
        }

        public ICommand RefreshCommand { get; }

        private async void Refresh()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            AddViewModel(GetViewModel<CurrentWeatherVm>());

            // 257885 - Ќью-…орк
            var forecastItems = await _weatherForecastDataProvider.GetForecastByCityIdAsync(4475).WithBusyIndicator(this);

            var groups = forecastItems.GroupBy(projection => projection.ForecastDateTime.Date)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.ToArray());

            foreach (var group in groups)
            {
                var weatherForecastVm = GetViewModel<WeatherForecastVm>();
                weatherForecastVm.Initialize(group.Key, group.Value);
                AddViewModel(weatherForecastVm, false);
            }
        }

        #endregion
    }
}