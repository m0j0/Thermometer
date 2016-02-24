namespace Thermometer.Infrastructure
{
    public enum CloudinessMeasureUnit
    {
        Percents
    }

    public enum PrecipitationMeasureUnit
    {
        Mm,
        Inches
    }

    public enum PrecipitationType
    {
        NoPrecipation,
        Rain,
        RainAndSnow,
        Snow
    }

    public enum PressureMeasureUnit
    {
        Mmhg,
        Hpa = 3
    }

    public enum SensorHistoryPeriod
    {
        Day,
        Week,
        Month
    }

    public enum TemperatureMeasureUnit
    {
        Celsius,
        Fahrenheit
    }

    public enum WindDirection
    {
        E,
        NE,
        N,
        NW,
        W,
        SW,
        S,
        SE,
        Calm
    }

    public enum WindMeasureUnit
    {
        Ms,
        Kmh,
        Mph
    }
}