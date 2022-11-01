using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Weather.Loaders
{
    public class BusinessesLoader
    {
        private string _yelpKey = "MHAgWu1VSCww2glra8e849tzB8Ou48hX93JjpWOCar1IxO7I4cbDa0CGGZA15fKTZx6ljw74rXrQhESQINJA85oWOo5p0q80_8ATt0NYkdTI-EvLNA8fWOFCwuRYY3Yx";

        /// <summary>
        /// Load the Yelp response
        /// </summary>
        /// <param name="city">Name of the city</param>
        /// <returns>The response string</returns>
        public string Load(string city)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://api.yelp.com/v3/businesses/search");

                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _yelpKey);

                string urlParameters = "?location=" + city;
                var response = client.GetAsync(urlParameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    var businessesInfo = response.Content.ReadAsStringAsync().Result;

                    return businessesInfo.Replace("\"", "");
                }
                else
                {
                    throw new Exception($"City not found: {city}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error in request to Yelp: " + ex.StackTrace);
            }
        }
    }
}
