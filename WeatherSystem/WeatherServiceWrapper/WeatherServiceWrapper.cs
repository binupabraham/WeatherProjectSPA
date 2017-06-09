using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherSystem.WeatherDataServiceClient;

namespace WeatherSystem.WeatherServiceWrapper
{
    public class WeatherServiceWrapper : IWeatherServiceWrapper
    {
        private GlobalWeatherSoapClient _client;
        private readonly string endpointName = "GlobalWeatherSoap";
        public WeatherServiceWrapper()
        {
            _client = new GlobalWeatherSoapClient(endpointName);
        }
        public string GetCitiesByCountry(string country)
        {
            return _client.GetCitiesByCountry(country);
        }

        public string GetWeatherInfoForCity(string city, string country)
        {
            return _client.GetWeather(city, country);
        }
    }
}