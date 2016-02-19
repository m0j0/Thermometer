using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using Newtonsoft.Json;
using Thermometer.Interfaces;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class Rp5WeatherForecastDataProvider : IWeatherForecastDataProvider
    {
        #region Fields

        private static readonly IFormatProvider EnUsCultureInfo = new CultureInfo("en-US");
        private readonly IMd5AlgorithmProvider _md5AlgorithmProvider;

        #endregion

        #region Constructors

        public Rp5WeatherForecastDataProvider(IMd5AlgorithmProvider md5AlgorithmProvider)
        {
            Should.NotBeNull(md5AlgorithmProvider, nameof(md5AlgorithmProvider));
            _md5AlgorithmProvider = md5AlgorithmProvider;
        }

        #endregion

        #region Implementation of interface

        public async Task<IList<WeatherForecastProjection>> GetForecastByCityIdAsync(int idCity)
        {
            var str1 = EncodeBase64String(idCity.ToString());
            var str2 = Rp5StringProcess(Rp5CityIdProcessMethod(idCity * 3.141D, 3).ToString(EnUsCultureInfo));
            var str3 = Rp5StringProcess(_md5AlgorithmProvider.GetMd5Hash(str2));
            var str4 = EncodeBase64String("ru");
            var requestUri = $"http://rp5.ru/wduck/i.php?city={str2}&api={str1}&io={str3}&l={str4}";

            using (var httpClient = new HttpClient())
            using (var httpResponse = await httpClient.GetAsync(requestUri))
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                var decodedRespose = DecodeResponse(response);
                var deserializedObject = JsonConvert.DeserializeObject<Rp5WeatherForecastRootObject>(decodedRespose);
                return ModelExtensions.ConvertToWeatherForecastProjections(deserializedObject);
            }
        }

        #endregion

        #region Methods

        private static double Rp5CityIdProcessMethod(double paramDouble, int paramInt)
        {
            int i = 10;
            for (int j = 1; j < paramInt;)
            {
                j += 1;
                i *= 10;
            }
            double d = i * paramDouble;
            paramDouble = d;
            if (d - (int) d >= 0.5D)
            {
                paramDouble = d + 1.0D;
            }
            return paramDouble / i;
        }

        private static string Rp5StringProcess(string paramString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in SplitString(paramString, 512))
            {
                sb.Append(EncodeBase64String(ReverseString(str)));
            }
            return ReverseString(sb.ToString()).Replace("=", "").Trim();
        }

        private static string DecodeResponse(string response)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in SplitString(ReverseString(response), 683))
            {
                var decodedString = DecodeBase64String(str);
                sb.Append(ReverseString(decodedString));
            }
            return sb.ToString();
        }

        private static IEnumerable<string> SplitString(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }

        private static string DecodeBase64String(string str)
        {
            var bytes = Convert.FromBase64String(PadBase64String(str));
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        private static string EncodeBase64String(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str)).Replace("=", "").Trim();
        }

        private static string PadBase64String(string str)
        {
            var padLenght = str.Length % 4;
            return str.PadRight(str.Length + (padLenght == 0 ? 0 : 4 - padLenght), '=');
        }

        private static string ReverseString(string str)
        {
            // http://stackoverflow.com/questions/228038/best-way-to-reverse-MagicMethod-string
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion
    }
}