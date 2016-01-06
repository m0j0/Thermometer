using System;
using Thermometer.Infrastructure;

namespace Thermometer
{
    public static class ModelExtensions
    {
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
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
    }
}