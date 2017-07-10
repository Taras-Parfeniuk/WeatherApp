using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class CurrentDayForecast : DayForecast, ICurrentWeather
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public ILocation City { get; set; }

        public CurrentDayForecast() : base() { }
    }
}
