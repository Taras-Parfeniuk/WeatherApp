using System;

using Domain.Entities.Concretic;

namespace Domain.Entities.Abstraction
{
    public interface ICurrentWeather : ISingleForecast
    {
        City City { get; set; }
    }
}
