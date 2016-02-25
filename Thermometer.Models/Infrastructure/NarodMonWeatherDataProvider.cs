using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thermometer.Extensions;
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

        #region Implementation

        public async Task<IList<DeviceProjection>> GetDevicesAsync()
        {
            var location = _applicationSettings.DefaultLocation;
            if (_applicationSettings.LocationConsent)
            {
                location = await _currentLocationDataProvider.GetCurrentUserLocationAsync();
            }
            var sensors = new SensorsNearbyRequest
            {
                Cmd = "sensorsNearby",
                Lat = location.Latitude,
                Lng = location.Longitude,
                Radius = _applicationSettings.DeviceRadius,
                Uuid = Uuid,
                ApiKey = ApiKey,
                Lang = "ru"
            };
            var response = await Send<SensorsNearbyResponse>(sensors);
            return NarodMonExtensions.ConvertSensorsNearbyResponseToDeviceProjections(response);
        }

        public async Task<IList<SensorHistoryData>> UpdateSensorHistoryAsync(int idSensor, SensorHistoryPeriod period, DateTime offset)
        {
            var request = new SensorLogRequest {Cmd = "sensorLog", Id =idSensor, Period = "day", Offset = 1, Uuid = Uuid, ApiKey = ApiKey};

            var response = await Send<SensorLogResponse>(request);
            
            var result = new List<SensorHistoryData>();
            if (response?.Data == null)
            {
                return result;
            }

            foreach (var responseData in response.Data)
            {
                result.Add(new SensorHistoryData(ModelExtensions.UnixTimeStampToDateTime(responseData.Time, true), responseData.Value));
            }
            return result;
        }

        #endregion

        #region Methods

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

        #endregion
    }
}