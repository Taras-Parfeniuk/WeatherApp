using System;

using Domain.Entities.Concretic;

namespace Domain.Entities.Abstraction
{
    public interface ICurrentWeather : IBaseForecast
    {
        double? CurrentTemperature { get; set; }
        DateTime Sunrise { get; set; }
        DateTime Sunset { get; set; }
        City City { get; set; }
    }
}
