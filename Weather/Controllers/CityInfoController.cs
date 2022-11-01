using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Loaders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weather.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CityInfoController : ControllerBase
    {
        private List<string> _cityNames = new List<string>()
        {
            "Bologna", "Jesi", "New York", "London", "Berlin"
        };

        /// <summary>
        /// Returns all cities' information
        /// </summary>
        /// <returns>A list of city's information</returns>
        /// <response code="200">Successful retrieve</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IEnumerable<City> Get()
        {
            WeatherLoader weatherLoader = new WeatherLoader();
            BusinessesLoader businessesLoader = new BusinessesLoader();

            List<City> result = new List<City>();

            foreach (string cityName in _cityNames)
            {
                string weatherInfo = weatherLoader.Load(cityName);
                string businessesInfo = businessesLoader.Load(cityName);

                result.Add(new City
                {
                    Name = cityName,
                    WeatherInfo = weatherInfo,
                    BusinessesInfo = businessesInfo
                });
            }

            return result;
        }

        /// <summary>
        /// Returns the specified city's information
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <returns>A city's information</returns>
        /// <response code="200">Successful retrieve</response>
        [HttpGet("{cityName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public City Get(string cityName)
        {
            WeatherLoader weatherLoader = new WeatherLoader();
            BusinessesLoader businessesLoader = new BusinessesLoader();

            string weatherInfo = weatherLoader.Load(cityName);
            string businessesInfo = businessesLoader.Load(cityName);

            City result = new City();


            result = new City
            {
                Name = cityName,
                WeatherInfo = weatherInfo,
                BusinessesInfo = businessesInfo
            };

            return result;
        }

    }
}
