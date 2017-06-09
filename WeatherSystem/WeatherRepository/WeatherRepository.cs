using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using WeatherSystem.WeatherDataServiceClient;
using WeatherSystem.WeatherServiceWrapper;
using WeatherSystem.Models;

namespace WeatherSystem.WeatherRepository
{
    public class WeatherRepository : IWeatherRepository
    {
        private IWeatherServiceWrapper _clientService;
        private readonly string endpointName = "GlobalWeatherSoap";
        public WeatherRepository(IWeatherServiceWrapper clientService)
        {
            _clientService = clientService;
        }
        public CountryAndCity GetCitiesByCountry(string country, bool exactMatch)
        {
            var cityCountry = new CountryAndCity() { Cities = new List<string>(), Countries = new List<string>()};
            var result = _clientService.GetCitiesByCountry(country);
            result = result.Replace("\n", "");
            XElement root = XElement.Parse(result);
            var countries = from item in root.Descendants("Country")
                            select (string)item;

            var countrylist = countries.ToList().Distinct();
            if (exactMatch)
            {
                cityCountry.Countries.AddRange(countrylist.Where(x => x.Equals(country)));
            }
            else
            {
                cityCountry.Countries.AddRange(countrylist);
            }

            if (cityCountry.Countries.Count() == 1)
            {
                var city = from item in root.Descendants("City")
                           select (string)item;
                city.ToList().ForEach(x => cityCountry.Cities.Add(x));
            }
           

            return cityCountry;
        }

        public WeatherInformation GetWeatherByCity(string city, string country)
        {
            var result = _clientService.GetWeatherInfoForCity(city, country);
            //XElement weather = XElement.Parse(result);
            XElement weather = XElement.Parse("<?xml version=\"1.0\" encoding=\"utf - 16\"?> <CurrentWeather> <Location>Maribor /Slivnica, Slovenia (LJMB) 46-29N 015-41E 265M</Location> <Time>May 20, 2014 - 04:30   PM EDT /   2014.05.20 2030 UTC</Time> <Wind> from the SSW (200 degrees) at 6 MPH (5 KT) (direction variable):0</Wind> <Visibility> greater than 7 mile(s):0</Visibility> <Temperature> 62 F (17 C)</Temperature> <DewPoint> 48 F (9 C)</DewPoint> <RelativeHumidity> 59%</RelativeHumidity> <Pressure> 30.03 in. Hg (1017 hPa)</Pressure> <Status>Success</Status> </CurrentWeather>");
            var weatherInformation = new WeatherInformation();
            weatherInformation.DewPoint = (from dewpoint in weather.Descendants("DewPoint")
                                          select (string)dewpoint).FirstOrDefault();
            weatherInformation.Location = (from location in weather.Descendants("Location")
                                          select (string)location).FirstOrDefault();
            weatherInformation.Time = (from time in weather.Descendants("Time")
                                           select (string)time).FirstOrDefault();
            weatherInformation.Wind = (from wind in weather.Descendants("Wind")
                                           select (string)wind).FirstOrDefault();
            weatherInformation.Visiblity = (from visibility in weather.Descendants("Visiblity")
                                           select (string)visibility).FirstOrDefault();
            weatherInformation.Temprature = (from temprature in weather.Descendants("Temprature")
                                           select (string)temprature).FirstOrDefault();
            weatherInformation.RelativeHumidity = (from relativeHumidity in weather.Descendants("RelativeHumidity")
                                             select (string)relativeHumidity).FirstOrDefault();
            weatherInformation.Pressure = (from pressure in weather.Descendants("Pressure")
                                             select (string)pressure).FirstOrDefault();

            return new WeatherInformation();
        }
    }
}