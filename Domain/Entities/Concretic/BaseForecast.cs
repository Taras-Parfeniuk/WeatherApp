using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class BaseForecast : IBaseForecast
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
    }
}
