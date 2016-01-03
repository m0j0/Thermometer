using System;
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
    }
}