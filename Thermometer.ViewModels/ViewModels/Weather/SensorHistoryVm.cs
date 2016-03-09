using System;
using System.Windows.Input;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Interfaces.Collections;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class SensorHistoryVm : CloseableViewModel
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;
        private readonly IToastPresenter _toastPresenter;
        private SensorHistoryPeriod _periodType = SensorHistoryPeriod.Day;
        private int _idSensor;

        #endregion

        #region Constructors

        public SensorHistoryVm(ICurrentWeatherDataProvider currentWeatherDataProvider, IToastPresenter toastPresenter)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            _toastPresenter = toastPresenter;

            RefreshCommand = new RelayCommand(Refresh);
            Items = new SynchronizedNotifiableCollection<SensorHistoryData>();
        }

        #endregion

        #region Properties

        public INotifiableCollection<SensorHistoryData> Items { get; }

        public SensorHistoryPeriod PeriodType
        {
            get { return _periodType; }
            set
            {
                _periodType = value;
                Refresh();
            }
        }

        public int IdSensor
        {
            get { return _idSensor; }
            private set
            {
                _idSensor = value;
                Refresh();
            }
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand { get; }

        private async void Refresh()
        {
            var items = await _currentWeatherDataProvider.UpdateSensorHistoryAsync(IdSensor, PeriodType, DateTime.Now).WithBusyIndicator(this);
            Items.Clear();
            Items.AddRange(items);
            _toastPresenter.ShowAsync("Добавлено записей: " + items.Count, ToastDuration.Short);
        }

        #endregion

        #region Methods

        protected override void OnInitializing(IDataContext context)
        {
            base.OnInitializing(context);

            IdSensor = context.GetData(Constants.IdSensor);
        }

        #endregion
    }
}
