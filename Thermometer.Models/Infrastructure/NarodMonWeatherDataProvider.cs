using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thermometer.Interfaces;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class NarodMonWeatherDataProvider : ICurrentWeatherDataProvider
    {

        #region Fields

        private readonly IApplicationSettings _applicationSettings;
        private readonly ICurrentLocationDataProvider _currentLocationDataProvider;
        private const string Uuid = "afca62c8c564cd1c1bfc42f0402fb42a";
        private const string ApiKey = "90GM7pC3RlMTM";
        private const string ApiStr = @"http://narodmon.ru/api";

        #endregion

        #region Constructors

        public NarodMonWeatherDataProvider(IApplicationSettings applicationSettings, ICurrentLocationDataProvider currentLocationDataProvider)
        {
            _applicationSettings = applicationSettings;
            _currentLocationDataProvider = currentLocationDataProvider;
        }

        #endregion


        private async Task<TResponse> Send<TResponse>(object request)
        {
            var json = JsonConvert.SerializeObject(request);
            using (var httpClient = new HttpClient())
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var httpResponse = await httpClient.PostAsync(ApiStr, stringContent))
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(response);

                //if (httpResponse.Content != null)
                //{
                //    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                //}

                //return "ниче не вернулось";
            }
        }

        public async Task<IList<DeviceProjection>> GetDevicesAsync()
        {
            var location = _applicationSettings.DefaultLocation;
            if (_applicationSettings.LocationConsent)
            {
                location = await _currentLocationDataProvider.GetCurrentUserLocationAsync();
            }
            var sensors = new SensorsNearbyRequest
            {
                cmd = "sensorsNearby",
                lat = (float) location.Latitude,
                lng = (float) location.Longitude,
                radius = _applicationSettings.Radius,
                uuid = Uuid,
                api_key = ApiKey,
                lang = "ru"
            };
            var response = await Send<SensorsNearbyResponse>(sensors);

            var result = new List<DeviceProjection>();
            foreach (var device in response.devices)
            {
                var projection = new DeviceProjection
                {
                    Id = device.id,
                    Name = device.name,
                    Location = device.name,
                    Distance = device.distance,
                    Latitude = device.lat,
                    Longitude = device.lng,
                    Sensors =
                        device.sensors.Select(
                            sensor =>
                                new SensorProjection
                                {
                                    Id = sensor.id,
                                    Type = sensor.type,
                                    Name = sensor.name,
                                    Value = sensor.value,
                                    Unit = sensor.unit,
                                    Time = ModelExtensions.UnixTimeStampToDateTime(sensor.time)
                                }).ToList()
                };
                result.Add(projection);
            }
            return result;
        }

        public async Task UpdateSensorHistoryAsync(SensorProjection sensor, SensorHistoryPeriod period, DateTime offset)
        {
            var request = new SensorLogRequest
            {
                Cmd = "sensorLog",
                Id = sensor.Id,
                Period = "day",
                Offset = 1,
                Uuid = Uuid,
                ApiKey = ApiKey
            };

            if (sensor.Data == null)
            {
                sensor.Data = new List<SensorHistoryData>();
            }

            var response = await Send<SensorLogResponse>(request);
            if (response?.Data == null)
            {
                return;
            }

            foreach (var responseData in response.Data)
            {
                sensor.Data.Add(new SensorHistoryData(ModelExtensions.UnixTimeStampToDateTime(responseData.Time), responseData.Value));
            }
        }
    }
}