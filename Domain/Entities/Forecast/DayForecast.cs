using System;

using Domain.Entities.Weather;
using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class DayForecast : DefaultForecast, IShortForecast
    {
        public Precipitation Rain { get; set; }
        public Precipitation Snow { get; set; }
    }
}
