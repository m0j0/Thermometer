using System;
using System.Linq;
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
using Thermometer.Modules;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class SensorHistoryVm : CloseableViewModel
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;
        private readonly IToastPresenter _toastPresenter;
        private readonly IMessagePresenter _messagePresenter;
        private SensorHistoryPeriod _periodType = SensorHistoryPeriod.Day;
        private int _idSensor;
        private int _offset = 1;

        #endregion

        #region Constructors

        public SensorHistoryVm(ICurrentWeatherDataProvider currentWeatherDataProvider, IToastPresenter toastPresenter, IMessagePresenter messagePresenter)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            _toastPresenter = toastPresenter;
            _messagePresenter = messagePresenter;

            RefreshCommand = new RelayCommand(Refresh);
            LoadMoreItemsCommand = new RelayCommand(LoadMoreItems);
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
            _offset = 1;
            var newItems = await _currentWeatherDataProvider.UpdateSensorHistoryAsync(IdSensor, PeriodType, _offset).WithBusyIndicator(this);
            Items.Update(newItems);
            _toastPresenter.ShowAsync("Загружено записей: " + newItems.Count, ToastDuration.Short);
        }

        public ICommand LoadMoreItemsCommand { get; }

        private async void LoadMoreItems()
        {
            _offset++;
            var newItems = await _currentWeatherDataProvider.UpdateSensorHistoryAsync(IdSensor, PeriodType, _offset).WithBusyIndicator(this);
            newItems.AddRange(Items);
            Items.Update(newItems.OrderBy(data => data.Time));

            _toastPresenter.ShowAsync("Подгружено записей: " + newItems.Count, ToastDuration.Short);
        }

        #endregion

        #region Methods

        protected override async void OnInitializing(IDataContext context)
        {
            base.OnInitializing(context);

            int idSensor;
            if (!context.TryGetData(Constants.IdSensor, out idSensor))
            {
                await _messagePresenter.ShowAsync("Ошибка при получении идентификатора датчика");
                await CloseAsync();
                return;
            }
            IdSensor = idSensor;
        }

        #endregion
    }
}
