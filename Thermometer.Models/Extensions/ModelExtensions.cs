using System;
using Thermometer.Infrastructure;

namespace Thermometer.Extensions
{
    public static class ModelExtensions
    {
        #region Public methods
        
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp, bool convertToLocalTime)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
            return convertToLocalTime ? dtDateTime.ToLocalTime() : dtDateTime;
        }

        public static string ToText(this SensorHistoryPeriod period)
        {
            switch (period)
            {
                case SensorHistoryPeriod.Day:
                    return "День";
                case SensorHistoryPeriod.Week:
                    return "Неделя";
                case SensorHistoryPeriod.Month:
                    return "Месяц";
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }
        }

        public static string ToText(this WindDirection direction)
        {
            switch (direction)
            {
                case WindDirection.E:
                    return "В";
                case WindDirection.NE:
                    return "С-В";
                case WindDirection.N:
                    return "С";
                case WindDirection.NW:
                    return "С-З";
                case WindDirection.W:
                    return "З";
                case WindDirection.SW:
                    return "Ю-З";
                case WindDirection.S:
                    return "Ю";
                case WindDirection.SE:
                    return "Ю-В";
                case WindDirection.Calm:
                    return "ШТЛ";
                default:
                    return string.Empty;
            }
        }

        public static string GetMeasureUnitAbbreviation(this TemperatureMeasureUnit mu)
        {
            switch (mu)
            {
                case TemperatureMeasureUnit.Celsius:
                    return "°C";
                case TemperatureMeasureUnit.Fahrenheit:
                    return "°C";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mu), mu, null);
            }
        }

        public static string GetMeasureUnitAbbreviation(this PressureMeasureUnit mu)
        {
            switch (mu)
            {
                case PressureMeasureUnit.Mmhg:
                    return "мм рт. ст.";
                //case PressureMeasureUnit.Inhg:
                //    return "дюймы рт. ст.";
                //case PressureMeasureUnit.Mbar:
                //    return "мбар";
                case PressureMeasureUnit.Hpa:
                    return "гПа";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mu), mu, null);
            }
        }

        public static string GetMeasureUnitAbbreviation(this WindMeasureUnit mu)
        {
            switch (mu)
            {
                case WindMeasureUnit.Ms:
                    return "м/с";
                case WindMeasureUnit.Kmh:
                    return "км/ч";
                case WindMeasureUnit.Mph:
                    return "мили/ч";
                //case WindMeasureUnit.Knots:
                //    return "узлы";
                //case WindMeasureUnit.Bft:
                //    return "Бфрт";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mu), mu, null);
            }
        }

        public static string GetMeasureUnitAbbreviation(this CloudinessMeasureUnit mu)
        {
            switch (mu)
            {
                case CloudinessMeasureUnit.Percents:
                    return "%";
                //case CloudinessMeasureUnit.Decimal:
                //    return "";
                //case CloudinessMeasureUnit.Oktas:
                //    return "окты";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mu), mu, null);
            }
        }

        public static string GetMeasureUnitAbbreviation(this PrecipitationMeasureUnit mu)
        {
            switch (mu)
            {
                case PrecipitationMeasureUnit.Mm:
                    return "мм";
                case PrecipitationMeasureUnit.Inches:
                    return "дюймы";
                default:
                    throw new ArgumentOutOfRangeException(nameof(mu), mu, null);
            }
        }

        #endregion
    }
}