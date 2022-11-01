using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather
{
    public class City
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// OpenWeatherApi response
        /// </summary>
        public string WeatherInfo { get; set; }

        /// <summary>
        /// YelpApi response
        /// </summary>
        public string BusinessesInfo { get; set; }

    }
}
