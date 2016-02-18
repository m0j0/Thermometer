using System.Collections.Generic;
using Newtonsoft.Json;

namespace Thermometer.JsonModels
{
    internal class Rp5WeatherForecastRootObject
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    internal class Temperature
    {
        [JsonProperty("c")]
        public double C { get; set; }

        [JsonProperty("f")]
        public int F { get; set; }
    }

    internal class Pr
    {
        [JsonProperty("mm")]
        public object Mm { get; set; }

        [JsonProperty("inches")]
        public object Inches { get; set; }
    }

    internal class Count
    {
        [JsonProperty("mm")]
        public double Mm { get; set; }

        [JsonProperty("inches")]
        public double Inches { get; set; }
    }

    internal class Precipitation
    {
        [JsonProperty("mm")]
        public double Mm { get; set; }

        [JsonProperty("inches")]
        public int Inches { get; set; }
    }

    internal class Archive
    {
        [JsonProperty("archive_string")]
        public string ArchiveString { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("temperature_sea")]
        public Temperature TemperatureSea { get; set; }

        [JsonProperty("wind_velocity")]
        public int WindVelocity { get; set; }

        [JsonProperty("horizontal_v")]
        public int HorizontalV { get; set; }

        [JsonProperty("vertical_c")]
        public int VerticalC { get; set; }

        [JsonProperty("sss")]
        public int Sss { get; set; }

        [JsonProperty("pr")]
        public Pr Pr { get; set; }
    }

    internal class Pressure
    {
        [JsonProperty("mmhg")]
        public int Mmhg { get; set; }

        [JsonProperty("inhg")]
        public int Inhg { get; set; }

        [JsonProperty("mbar")]
        public int Mbar { get; set; }

        [JsonProperty("hpa")]
        public int Hpa { get; set; }
    }

    internal class WindVelocity
    {
        [JsonProperty("ms")]
        public int Ms { get; set; }

        [JsonProperty("kmh")]
        public int Kmh { get; set; }

        [JsonProperty("mph")]
        public int Mph { get; set; }

        [JsonProperty("knots")]
        public int Knots { get; set; }

        [JsonProperty("bft")]
        public int Bft { get; set; }
    }

    internal class WindGusts
    {
        [JsonProperty("ms")]
        public int Ms { get; set; }

        [JsonProperty("kmh")]
        public int Kmh { get; set; }

        [JsonProperty("mph")]
        public int Mph { get; set; }

        [JsonProperty("knots")]
        public int Knots { get; set; }

        [JsonProperty("bft")]
        public int Bft { get; set; }
    }

    internal class CurrentWeather
    {
        [JsonProperty("archive")]
        public Archive Archive { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("last")]
        public int Last { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("feel_temperature")]
        public Temperature FeelTemperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("humidity_hint")]
        public string HumidityHint { get; set; }

        [JsonProperty("pressure")]
        public Pressure Pressure { get; set; }

        [JsonProperty("pressure_icon")]
        public int PressureIcon { get; set; }

        [JsonProperty("pressure_hint")]
        public string PressureHint { get; set; }

        [JsonProperty("cloud_cover")]
        public int CloudCover { get; set; }

        [JsonProperty("phenomenon")]
        public int Phenomenon { get; set; }

        [JsonProperty("wind_velocity")]
        public WindVelocity WindVelocity { get; set; }

        [JsonProperty("wind_velocity_hint")]
        public string WindVelocityHint { get; set; }

        [JsonProperty("wind_direction")]
        public int WindDirection { get; set; }

        [JsonProperty("wind_direction_hint")]
        public string WindDirectionHint { get; set; }

        [JsonProperty("wind_gusts")]
        public WindGusts WindGusts { get; set; }
    }

    internal class Forecast
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public IList<IList<ForecastItem>> Items { get; set; }
    }

    internal class Backgrounds
    {
        [JsonProperty("day")]
        public IList<string> Day { get; set; }

        [JsonProperty("night")]
        public IList<string> Night { get; set; }

        [JsonProperty("update")]
        public int Update { get; set; }
    }

    internal class Response
    {
        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("local_time")]
        public int LocalTime { get; set; }

        [JsonProperty("gmt_add")]
        public int GmtAdd { get; set; }

        [JsonProperty("where")]
        public string Where { get; set; }

        [JsonProperty("where_unique")]
        public string WhereUnique { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }

        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }

        [JsonProperty("backgrounds")]
        public Backgrounds Backgrounds { get; set; }
    }

    internal class CloudCover
    {
        [JsonProperty("pct")]
        public int Pct { get; set; }

        [JsonProperty("decimal")]
        public int Decimal { get; set; }

        [JsonProperty("oktas")]
        public int Oktas { get; set; }
    }

    internal class CloudCoverHint
    {
        [JsonProperty("pct")]
        public string Pct { get; set; }

        [JsonProperty("decimal")]
        public string Decimal { get; set; }

        [JsonProperty("oktas")]
        public string Oktas { get; set; }
    }

    internal class Phenomenon
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("count")]
        public Count Count { get; set; }

        [JsonProperty("fraction")]
        public int Fraction { get; set; }
    }

    internal class PrecipitationHint
    {
        [JsonProperty("mm")]
        public string Mm { get; set; }

        [JsonProperty("inches")]
        public string Inches { get; set; }
    }

    internal class ForecastItem
    {
        [JsonProperty("gmt")]
        public int Gmt { get; set; }

        [JsonProperty("gmt_string")]
        public string GmtString { get; set; }

        [JsonProperty("cloud_cover")]
        public CloudCover CloudCover { get; set; }

        [JsonProperty("cloud_cover_hint")]
        public CloudCoverHint CloudCoverHint { get; set; }

        [JsonProperty("phenomenon")]
        public Phenomenon Phenomenon { get; set; }

        [JsonProperty("precipitation")]
        public Precipitation Precipitation { get; set; }

        [JsonProperty("precipitation_hint")]
        public PrecipitationHint PrecipitationHint { get; set; }

        [JsonProperty("precipitation_type")]
        public int PrecipitationType { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("feel_temperature")]
        public Temperature FeelTemperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("humidity_hint")]
        public string HumidityHint { get; set; }

        [JsonProperty("pressure")]
        public Pressure Pressure { get; set; }

        [JsonProperty("pressure_hint")]
        public string PressureHint { get; set; }

        [JsonProperty("wind_velocity")]
        public WindVelocity WindVelocity { get; set; }

        [JsonProperty("wind_gusts")]
        public WindGusts WindGusts { get; set; }

        [JsonProperty("wind_velocity_hint")]
        public string WindVelocityHint { get; set; }

        [JsonProperty("wind_direction")]
        public int WindDirection { get; set; }

        [JsonProperty("wind_direction_hint")]
        public string WindDirectionHint { get; set; }

        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }

        [JsonProperty("moonrise")]
        public string Moonrise { get; set; }

        [JsonProperty("moonset")]
        public string Moonset { get; set; }

        [JsonProperty("moon_phase")]
        public int MoonPhase { get; set; }

        [JsonProperty("moon_phase_hint")]
        public string MoonPhaseHint { get; set; }
    }
}