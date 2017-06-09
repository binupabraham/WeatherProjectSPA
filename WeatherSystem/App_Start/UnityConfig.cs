using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WeatherSystem.WeatherRepository;
using WeatherSystem.WeatherServiceWrapper;

namespace WeatherSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here

            container.RegisterType<IWeatherRepository, WeatherRepository.WeatherRepository>();
            container.RegisterType<IWeatherServiceWrapper, WeatherServiceWrapper.WeatherServiceWrapper>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}