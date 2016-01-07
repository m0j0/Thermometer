using System;
using System.Collections.Generic;
using MugenMvvmToolkit.Models;

namespace Thermometer.Projections
{
    public class SensorProjection : NotifyPropertyChangedBase
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public float Value { get; set; }

        public string Unit { get; set; }

        public DateTime Time { get; set; }

        public IList<SensorHistoryData> Data { get; set; }
    }
    
    public class SensorHistoryData
    {
        public SensorHistoryData(DateTime time, double value)
        {
            Time = time;
            Value = value;
        }

        public DateTime Time { get; }

        public double Value { get; }
    }
}