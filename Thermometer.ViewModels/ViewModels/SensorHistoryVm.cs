using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Items = new List<Tuple<int, int>>();
            for (int i = 0; i < 20; i++)
            {
                Items.Add(Tuple.Create(i, random.Next(0, 50)));
            }
        }

        #endregion

        #region Properties

        public IList<Tuple<SensorHistoryPeriod, string>> PeriodTypes { get; }

        public SensorHistoryPeriod SelectedPeriodType { get; set; }

        public IList<Tuple<int, int>> Items { get; }

        public string DisplayName { get; set; } = "График";

        public SensorProjection Sensor { get; private set; }

        #endregion

        #region Methods

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SelectedPeriodType = SensorHistoryPeriod.Day;
        }

        public void Initialize(SensorProjection projection)
        {
            Sensor = projection;
        }

        #endregion
    }
}
