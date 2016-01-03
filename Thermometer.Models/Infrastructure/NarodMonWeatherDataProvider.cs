using System.Net;
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


        private async Task<string> Send()
        {
            //await Task.Delay(3000);

            using (var httpClient = new HttpClient())
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

                var json = JsonConvert.SerializeObject(sensors);


                var t = new StringContent(json, Encoding.UTF8, "application/json");
                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync(ApiStr, t);

                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    return await httpResponse.Content.ReadAsStringAsync();

                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                }

                return "ниче не вернулось";
            }
        }

        public Task<string> GetInfoAsync()
        {
            return Send();
        }
    }
}