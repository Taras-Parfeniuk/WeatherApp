using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class CurrentDayForecast : BaseForecast, ICurrentWeather
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public City City { get; set; }
        public double? CurrentTemperature { get; set; }

        public CurrentDayForecast(){ }
    }
}
