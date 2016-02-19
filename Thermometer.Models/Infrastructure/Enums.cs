namespace Thermometer.Infrastructure
{
    public enum SensorHistoryPeriod
    {
        Day = 0,
        Week = 1,
        Month = 2
    }

    public enum FactCloudCoverHint
    {
        Clear = 0,
        MostlyClear = 1,
        CloudyWithClearBreaks = 2,
        MostlyCloudy = 3,
        Overcast = 4,
        NotAvailable = 5
    }

    public enum FactPhenomenonHint
    {
        SlightSnow = 0,
        ModerateSnow = 1,
        HeavySnow = 2,
        SlightRain = 3,
        ModerateRain = 4,
        HeavyRain = 5,
        SlightRainAndSnowMixed = 6,
        ModerateRainAndSnowMixed = 7,
        HeavyRainAndSnowMixed = 8,
        Thunderstorm = 9,
        Fog = 10,
        Drizzle = 11,
        Blizzard = 12,
        Fog2 = 13
    }

    public enum Rp5WindDirectionForecast
    {
        E = 361,
        NE = 360,
        N = 359,
        NW = 366,
        W = 365,
        SW = 364,
        S = 363,
        SE = 362,
        Calm = 400,
        NotAvailable = 0
    }

    public enum Rp5ForecastCloudCoverIcon
    {
        DayIcon1 = 1,
        DayIcon2 = 2,
        DayIcon3 = 3,
        DayIcon4 = 4,
        DayIcon5 = 5,
        DayIcon6 = 6,
        DayIcon7 = 7,
        DayIcon8 = 8,
        NightIcon1 = 11,
        NightIcon2 = 12,
        NightIcon3 = 13,
        NightIcon4 = 14,
        NightIcon5 = 15,
        NightIcon6 = 16,
        NightIcon7 = 17,
        NightIcon8 = 18
    }

    public enum Rp5PrecipitationIcon
    {
        NoPrecipation = 0,
        Rain1 = 11,
        Rain2 = 12,
        Rain3 = 13,
        Rain4 = 14,
        Rain5 = 15,
        RainAndSnow1 = 21,
        RainAndSnow2 = 22,
        RainAndSnow3 = 23,
        RainAndSnow4 = 24,
        RainAndSnow5 = 25,
        Snow1 = 31,
        Snow2 = 32,
        Snow3 = 33,
        Snow4 = 34,
        Snow5 = 35
    }
}