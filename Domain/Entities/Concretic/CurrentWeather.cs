using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class CurrentWeather : SingleForecast, ICurrentWeather
    {
        public City City { get; set; }

        public CurrentWeather(){ }
    }
}
