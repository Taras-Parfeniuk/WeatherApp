using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Abstraction;
using Domain.Entities.Weather;
using Domain.Entities.Temperature;

namespace Domain.Entities.Forecast
{
    public class DefaultForecast : IForecast
    {
        public WeatherState Weather { get; set; }
        public DefaultTemperature Temperature { get; set; }
        public Measurements MainMeathurements { get; set; }
        public Wind Wind { get; set; }
        public double? Cloudiness { get; set; }
        public DateTime MeathurementsTime { get; set; }
        public DateTime ForecastTime { get; set; }
    }
}
