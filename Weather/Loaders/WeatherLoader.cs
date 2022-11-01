using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Weather.Loaders
{
    public class WeatherLoader
    {
        private string _openWeatherMapKey = "897ab118347659c17d7ec937461ef3fc";
        private string _uri = "https://api.openweathermap.org/data/2.5/weather";

        /// <summary>
        /// Load OpenWeatherApi response
        /// </summary>
        /// <param name="city">Name of the city</param>
        /// <returns>The response string</returns>
        public string Load(string city)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(_uri);

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                string urlParameters = "?q=" + city + "&appid=" + _openWeatherMapKey;
                var response = client.GetAsync(urlParameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    var wheaterInfo = response.Content.ReadAsStringAsync().Result;

                    return wheaterInfo.Replace("\"", "");
                }
                else
                {
                    throw new Exception($"Error: City not found: {city}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in request to OpenWeatherMap: " + ex.StackTrace);
            }
        }
    }
}
