using System;

using Domain.Entities.Weather;
using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class DayForecast : IForecast
    {
        public WeatherState Weather { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public double? MorningTemperature { get; set; }
        public double? DayTemperature { get; set; }
        public double? EveningTemperature { get; set; }
        public double? CurrentTemperature { get; set; }
        public Measurements MainMeathurements { get; set; }
        public Wind Wind { get; set; }
        public double? Cloudiness { get; set; }
        public DateTime MeathurementsTime { get; set; }
        public DateTime ForecastTime { get; set; }

        public Precipitation Rain { get; set; }
        public Precipitation Snow { get; set; }
    }
}
