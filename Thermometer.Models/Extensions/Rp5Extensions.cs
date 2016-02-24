using System;
using System.Collections.Generic;
using Thermometer.Infrastructure;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer.Extensions
{
    public static class Rp5Extensions
    {
        #region Methods

        internal static List<WeatherForecastProjection> ConvertToWeatherForecastProjections(Rp5WeatherForecastRootObject deserializeObject)
        {
            var result = new List<WeatherForecastProjection>();
            foreach (var forecastItems in deserializeObject.Response.Forecast.Items)
            {
                foreach (var forecastItem in forecastItems)
                {
                    result.Add(new WeatherForecastProjection
                    {
                        ForecastDateTime = ModelExtensions.UnixTimeStampToDateTime(forecastItem.Gmt, false),
                        Temperature = new TemperatureProjection {Celsius = forecastItem.Temperature.C, Fahrenheit = forecastItem.Temperature.F},
                        FeelTemperature = new TemperatureProjection {Celsius = forecastItem.FeelTemperature.C, Fahrenheit = forecastItem.FeelTemperature.F},
                        Cloudiness =
                            new CloudinessProjection
                            {
                                Percents = forecastItem.CloudCover.Pct,
                                Decimal = forecastItem.CloudCover.Decimal,
                                Oktas = forecastItem.CloudCover.Oktas
                            },
                        WindSpeed =
                            new WindProjection
                            {
                                Ms = forecastItem.WindVelocity.Ms,
                                Kmh = forecastItem.WindVelocity.Kmh,
                                Mph = forecastItem.WindVelocity.Mph,
                                Knots = forecastItem.WindVelocity.Knots,
                                Bft = forecastItem.WindVelocity.Bft
                            },
                        WindGusts = 
                            new WindProjection
                            {
                                Ms = forecastItem.WindGusts.Ms,
                                Kmh = forecastItem.WindGusts.Kmh,
                                Mph = forecastItem.WindGusts.Mph,
                                Knots = forecastItem.WindGusts.Knots,
                                Bft = forecastItem.WindGusts.Bft
                            },
                        Pressure =
                            new PressureProjection
                            {
                                Hpa = forecastItem.Pressure.Hpa,
                                Inhg = forecastItem.Pressure.Inhg,
                                Mbar = forecastItem.Pressure.Mbar,
                                Mmhg = forecastItem.Pressure.Mmhg
                            },
                        Precipitation = new PrecipitationProjection {Mm = forecastItem.Precipitation.Mm, Inches = forecastItem.Precipitation.Inches},
                        PrecipitationType = (PrecipitationType) forecastItem.PrecipitationType,
                        WindDirection = GetWindDirection(forecastItem.WindDirection),
                        Humidity = forecastItem.Humidity,
                        Sunrise = ModelExtensions.UnixTimeStampToDateTime(forecastItem.Sunrise, false),
                        Sunset = ModelExtensions.UnixTimeStampToDateTime(forecastItem.Sunset, false)
                    });
                }
            }
            return result;
        }

        private static WindDirection GetWindDirection(int windDirection)
        {
            if (windDirection == 400)
            {
                return WindDirection.Calm;
            }
            if (windDirection == 366)
            {
                return WindDirection.NW;
            }
            if (windDirection == 365)
            {
                return WindDirection.W;
            }
            if (windDirection == 364)
            {
                return WindDirection.SW;
            }
            if (windDirection == 363)
            {
                return WindDirection.S;
            }
            if (windDirection == 362)
            {
                return WindDirection.SE;
            }
            if (windDirection == 361)
            {
                return WindDirection.E;
            }
            if (windDirection == 360)
            {
                return WindDirection.NE;
            }
            if (windDirection == 359)
            {
                return WindDirection.N;
            }
            throw new ArgumentException(nameof(windDirection));
        }

        public static int GetForecastCloudCoverIconNumber(int cloudCoverPct)
        {
            if (cloudCoverPct >= 100)
            {
                return 8;
            }
            if (cloudCoverPct >= 80)
            {
                return 7;
            }
            if (cloudCoverPct >= 70)
            {
                return 6;
            }
            if (cloudCoverPct >= 50)
            {
                return 5;
            }
            if (cloudCoverPct >= 30)
            {
                return 4;
            }
            if (cloudCoverPct >= 20)
            {
                return 3;
            }
            if (cloudCoverPct > 0)
            {
                return 2;
            }
            return 1;
        }

        public static int GetPrecipitationIconNumber(double precipitationInMm)
        {
            if (precipitationInMm >= 24.8D)
            {
                return 5;
            }
            if (precipitationInMm >= 6.1D)
            {
                return 4;
            }
            if (precipitationInMm >= 3.1D)
            {
                return 3;
            }
            if (precipitationInMm >= 1.1D)
            {
                return 2;
            }
            if (precipitationInMm > 0.0D)
            {
                return 1;
            }
            return 0;
        }

        public static bool IsDayForecast(WeatherForecastProjection projection)
        {
            return (projection.ForecastDateTime > projection.Sunrise) && (projection.ForecastDateTime < projection.Sunset);
        }

        #endregion
    }
}