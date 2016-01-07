using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit.Collections;
using MugenMvvmToolkit.Interfaces.Collections;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Infrastructure;
using Thermometer.Interfaces;
using Thermometer.Projections;

namespace Thermometer.ViewModels
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

            var random = new Random();
            Items = new SynchronizedNotifiableCollection<SensorHistoryData>();
            for (int i = 0; i < 24; i++)
            {
                Items.Add(new SensorHistoryData(DateTime.Now - TimeSpan.FromHours(i), random.NextDouble() * 50));
            }
        }

        #endregion

        #region Properties

        public IList<Tuple<SensorHistoryPeriod, string>> PeriodTypes { get; }

        public SensorHistoryPeriod SelectedPeriodType { get; set; }

        public INotifiableCollection<SensorHistoryData> Items { get; }

        public string DisplayName { get; set; } = "График";

        public SensorProjection Sensor { get; private set; }

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SelectedPeriodType = SensorHistoryPeriod.Day;
        }

        public async void Initialize(SensorProjection projection)
        {
            Sensor = projection;
            await _currentWeatherDataProvider.UpdateSensorHistoryAsync(Sensor, SelectedPeriodType, DateTime.Now).WithBusyIndicator(this);
            Items.Clear();
            Items.AddRange(projection.Data);
        }

        #endregion
    }
}
