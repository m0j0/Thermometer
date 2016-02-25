using System;
using MugenMvvmToolkit.Models;

namespace Thermometer.Projections
{
    public class SensorProjection : NotifyPropertyChangedBase
    {
        #region Properties

        public int Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public string Unit { get; set; }

        public DateTime Time { get; set; }

        public bool IsPinned { get; set; }

        #endregion
    }

    public class SensorHistoryData
    {
        #region Constructors

        public SensorHistoryData(DateTime time, double value)
        {
            Time = time;
            Value = value;
        }

        #endregion

        #region Properties

        public DateTime Time { get; }

        public double Value { get; set; }

        #endregion
    }
}