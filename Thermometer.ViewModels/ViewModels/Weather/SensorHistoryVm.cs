using System;
using System.Collections.Generic;
using System.Windows.Input;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Interfaces.Collections;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Extensions;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels.Weather
{
    public class SensorHistoryVm : CloseableViewModel, IHasDisplayName
    {
        #region Fields

        private readonly ICurrentWeatherDataProvider _currentWeatherDataProvider;

        #endregion

        #region Constructors

        public SensorHistoryVm(ICurrentWeatherDataProvider currentWeatherDataProvider)
        {
            _currentWeatherDataProvider = currentWeatherDataProvider;
            PeriodTypes = new[]
            {
                Tuple.Create(SensorHistoryPeriod.Day, SensorHistoryPeriod.Day.ToText()), Tuple.Create(SensorHistoryPeriod.Week, SensorHistoryPeriod.Week.ToText()),
                Tuple.Create(SensorHistoryPeriod.Month, SensorHistoryPeriod.Month.ToText())
            };

            Items = new SynchronizedNotifiableCollection<SensorHistoryData>();
        }

        #endregion

        #region Properties

        public IList<Tuple<SensorHistoryPeriod, string>> PeriodTypes { get; }

        public SensorHistoryPeriod SelectedPeriodType { get; set; }

        public INotifiableCollection<SensorHistoryData> Items { get; }

        public string DisplayName { get; set; } = "График";
        
        public int IdSensor { get; private set; }

        #endregion

        #region Commands

        public ICommand RefreshCommand { get; }

        #endregion

        #region Methods

        protected override async void OnInitializing(IDataContext context)
        {
            base.OnInitializing(context);

            IdSensor = context.GetData(Constants.IdSensor);

            var items =  await _currentWeatherDataProvider.UpdateSensorHistoryAsync(IdSensor, SelectedPeriodType, DateTime.Now).WithBusyIndicator(this);
            Items.Clear();
            Items.AddRange(items);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SelectedPeriodType = SensorHistoryPeriod.Day;
        }

        #endregion
    }
}
