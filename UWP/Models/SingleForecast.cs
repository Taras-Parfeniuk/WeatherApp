using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Models
{
    public class SingleForecast
    {
        public string WeatherIcon { get; set; }
        public string WeatherState { get; set; }
        public string WeatherDescription { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public int? DefaultPressure { get; set; }
        public int? Humidity { get; set; }
        public double? WindSpeed { get; set; }
        public double? Cloudiness { get; set; }
        public DateTime ForecastTime { get; set; }
        public double? MorningTemperature { get; set; }
        public double? DayTemperature { get; set; }
        public double? EveningTemperature { get; set; }
        public double? CurrentTemperature { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }


    }
}
