using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thermometer.Interfaces;

namespace Thermometer.Infrastructure
{
    internal class Rp5WeatherForecastDataProvider : IWeatherForecastDataProvider
    {
        public async Task<string> GetForecastByCityIdAsync(int idCity)
        {
            using (var httpClient = new HttpClient())
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "http://rp5.ru/"))
            {
                requestMessage.Headers.Add("headername", "header value");
                var parameters = new Dictionary<string, string>();
                parameters["city"] = "xQDM1UjL5cTN";
                parameters["api"] = "NDQ3NQ";
                parameters["io"] = "YTYiJmMkhDZhJGZkdzM1YDO1QWO5kDO5UTZyUGZjJDM";
                parameters["l"] = "ZW4";
                // /wduck/i.php?city=xQDM1UjL5cTN&api=NDQ3NQ&io=YTYiJmMkhDZhJGZkdzM1YDO1QWO5kDO5UTZyUGZjJDM&l=ZW4 
                using (var httpResponse = await httpClient.GetAsync("http://rp5.ru/wduck/i.php?city=xQDM1UjL5cTN&api=NDQ3NQ&io=YTYiJmMkhDZhJGZkdzM1YDO1QWO5kDO5UTZyUGZjJDM&l=ZW4"))
                {
                    var response = await httpResponse.Content.ReadAsStringAsync();
                  //  return JsonConvert.DeserializeObject<TResponse>(response);

                    //if (httpResponse.Content != null)
                    //{
                    //    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                    //}

                    return DecodeResponse(response);
                }
            }
        }

        #region Methods


        private static double MagicMethod(double paramDouble, int paramInt)
        {
            int i = 10;
            for (int j = 1; j < paramInt;)
            {
                j += 1;
                i *= 10;
            }
            double d = i * paramDouble;
            paramDouble = d;
            if (d - (int)d >= 0.5D)
            {
                paramDouble = d + 1.0D;
            }
            return paramDouble / i;
        }

        private static String MagicMethod2(String paramString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in SplitString(paramString, 512))
            {
                sb.Append(EncodeBase64String(ReverseString(str)));
            }
            return ReverseString(sb.ToString()).Replace("=", "").Trim();
        }

        private static string GetMd5Hash(string str)
        {
            return str;
/*            byte[] encodedPassword = Encoding.UTF8.GetBytes(str);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            StringBuilder sb = new StringBuilder();
            for (int n = 0; n < hash.Length; n++)
            {
                sb.Append(hash[n].ToString("x2"));
            }
            return sb.ToString();*/
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