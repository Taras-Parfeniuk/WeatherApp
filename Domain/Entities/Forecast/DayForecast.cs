using System;

using Domain.Entities.Weather;
using Domain.Entities.Abstraction;
using Domain.Entities.Temperature;

namespace Domain.Entities.Forecast
{
    public class DayForecast : IForecast
    {
        public Guid Id { get; set; }

        public WeatherState Weather { get; set; }
        public DefaultTemperature Temperature { get; set; }
        public Measurements MainMeathurements { get; set; }
        public Wind Wind { get; set; }
        public double? Cloudiness { get; set; }
        public DateTime MeathurementsTime { get; set; }
        public DateTime ForecastTime { get; set; }

        public Precipitation Rain { get; set; }
        public Precipitation Snow { get; set; }

        public DayForecast()
        {
            Id = Guid.NewGuid();
        }
    }
}
