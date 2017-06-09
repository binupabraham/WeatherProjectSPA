using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherSystem.Models;

namespace WeatherSystem.WeatherRepository
{
    public interface IWeatherRepository
    {
        CountryAndCity GetCitiesByCountry(string country, bool exactMatch);
        WeatherInformation GetWeatherByCity(string city, string country);

    }
}
