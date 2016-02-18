using System;
using MugenMvvmToolkit.Models;

namespace Thermometer.Projections
{
    public class WeatherForecastProjection : NotifyPropertyChangedBase
    {
        public DateTime ForecastDateTime { get; set; }

        public double Temperature { get; set; }

        public double FeelTemperature { get; set; }

        public int Cloudiness { get; set; }
    }
}