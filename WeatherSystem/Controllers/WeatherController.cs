using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherSystem.Models;
using WeatherSystem.WeatherRepository;

namespace WeatherSystem.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherRepository _repository;

        public WeatherController(IWeatherRepository repository)
        {
            _repository = repository;
        }


        [Route("api/weather/GetCities/{country}/{exactMatch}")]
        [HttpGet]
        public IHttpActionResult GetCities(string country, bool exactMatch)
        {
            var result = _repository.GetCitiesByCountry(country, exactMatch);
            return Json<CountryAndCity>(result);
        }
        [Route("api/weather/GetWeather/{city}/{country}")]
        [HttpGet]
        public IHttpActionResult GetWeatherInformation(string city, string country)
        {
            var result = _repository.GetWeatherByCity(city, country);
            return Json(result);
        }
    }
}
