using System;
using Thermometer.Infrastructure;

namespace Thermometer.Projections
{
    public class WeatherForecastProjection
    {
        public DateTime ForecastDateTime { get; internal set; }

        public TemperatureProjection Temperature { get; internal set; }

        public TemperatureProjection FeelTemperature { get; internal set; }

        public CloudinessProjection Cloudiness { get; internal set; }

        public WindProjection WindSpeed { get; internal set; }

        public WindProjection WindGusts { get; internal set; }

        public WindDirection WindDirection { get; internal set; }

        public PressureProjection Pressure { get; internal set; }

        public PrecipitationProjection Precipitation { get; internal set; }

        public PrecipitationType PrecipitationType { get; internal set; }

        public int Humidity { get; internal set; }

        public DateTime Sunrise { get; internal set; }

        public DateTime Sunset { get; internal set; }
    }
    
    public class TemperatureProjection
    {
        public double Celsius { get; internal set; }

        public int Fahrenheit { get; internal set; }
    }

    public class CloudinessProjection
    {
        public int Percents { get; internal set; }

        public int Decimal { get; internal set; }

        public int Oktas { get; internal set; }
    }

    public class PrecipitationProjection
    {
        public double Mm { get; internal set; }

        public int Inches { get; internal set; }
    }

    public class PressureProjection
    {
        public int Mmhg { get; internal set; }

        public int Inhg { get; internal set; }

        public int Mbar { get; internal set; }

        public int Hpa { get; internal set; }
    }

    public class WindProjection
    {
        public int Ms { get; internal set; }

        public int Kmh { get; internal set; }

        public int Mph { get; internal set; }

        public int Knots { get; internal set; }

        public int Bft { get; internal set; }
    }
}