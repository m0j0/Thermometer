﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thermometer.Interfaces;
using Thermometer.JsonModels;

namespace Thermometer.Infrastructure
{
    internal class NarodMonWeatherDataProvider : ICurrentWeatherDataProvider
    {
        const string Uuid = "afca62c8c564cd1c1bfc42f0402fb42a";
        const string ApiKey = "90GM7pC3RlMTM";
        const string ApiStr = @"http://narodmon.ru/api";


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

        public async Task<string> GetInfoAsync()
        {
            var sensors = new SensorsNearbyRequest()
            {
                cmd = "sensorsNearby",
                lat = 56.2F,
                lng = 92.58F,
                radius = 30,
                uuid = Uuid,
                api_key = ApiKey,
                lang = "ru"
            };
            var result = await Send<SensorsNearbyResponse>(sensors);

            return result.devices.Length.ToString();
        }
    }
}