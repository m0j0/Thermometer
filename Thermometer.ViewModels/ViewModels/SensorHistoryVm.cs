using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit.ViewModels;
using Thermometer.Infrastructure;

namespace Thermometer.ViewModels
{
    public class SensorHistoryVm : CloseableViewModel
    {
        public SensorHistoryVm()
        {
            PeriodTypes = new[]
            {
                Tuple.Create(SensorHistoryPeriod.Day, SensorHistoryPeriod.Day.ToText()),
                Tuple.Create(SensorHistoryPeriod.Week, SensorHistoryPeriod.Week.ToText()),
                Tuple.Create(SensorHistoryPeriod.Month, SensorHistoryPeriod.Month.ToText())
            };

            var random = new Random();
            Items = new List<Tuple<int, int>>();
            for (int i = 0; i < 20; i++)
            {
                Items.Add(Tuple.Create(i, random.Next(0, 50)));
            }
        }

        public IList<Tuple<SensorHistoryPeriod, string>> PeriodTypes { get; }

        public SensorHistoryPeriod SelectedPeriodType { get; set; }

        public IList<Tuple<int, int>> Items { get; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SelectedPeriodType = SensorHistoryPeriod.Day;
        }
    }
}
