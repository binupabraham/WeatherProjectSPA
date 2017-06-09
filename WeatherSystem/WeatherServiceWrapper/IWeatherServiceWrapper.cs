namespace WeatherSystem.WeatherServiceWrapper
{
    public interface IWeatherServiceWrapper
    {
        string GetCitiesByCountry(string country);
        string GetWeatherInfoForCity(string city, string country);
    }
}
