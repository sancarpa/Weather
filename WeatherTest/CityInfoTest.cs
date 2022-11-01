using NUnit.Framework;
using System;
using System.Linq;
using Weather.Controllers;

namespace WeatherTest
{
    public class CityInfoTest
    {
        [Test]
        public void TestGetAll()
        {
            CityInfoController cityInfoController = new CityInfoController();
            var response = cityInfoController.Get();
            Assert.AreEqual(response.Count(), 5);
        }

        [Test]
        public void TestGet()
        {
            CityInfoController cityInfoController = new CityInfoController();
            var response = cityInfoController.Get("Bologna");
            Assert.That(!string.IsNullOrWhiteSpace(response.BusinessesInfo));

            //Wrong city name
            Assert.Throws<Exception>(delegate
            {
                cityInfoController.Get("BolognaSbagliata");
            });
        }
    }
}