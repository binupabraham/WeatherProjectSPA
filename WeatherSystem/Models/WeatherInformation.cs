using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherSystem.Models
{
    public class WeatherInformation
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visiblity { get; set; }
        public string Skyconditions { get; set; }
        public string Temprature { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}