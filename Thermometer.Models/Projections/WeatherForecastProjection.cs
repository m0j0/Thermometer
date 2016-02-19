using System;
using MugenMvvmToolkit.Models;
using Thermometer.Infrastructure;

namespace Thermometer.Projections
{
    public class WeatherForecastProjection : NotifyPropertyChangedBase
    {
        public DateTime ForecastDateTime { get; set; }

        public double Temperature { get; set; }

        public double FeelTemperature { get; set; }

        public int Cloudiness { get; set; }

        public Rp5WindDirectionForecast WindDirection { get; set; }

        public Rp5ForecastCloudCoverIcon CloudCoverIcon { get; set; }
    }
}