using System;

namespace Domain.Entities.Abstraction
{
    public interface ICurrentWeather : IForecast
    {
        DateTime Sunrise { get; set; }
        DateTime Sunset { get; set; }
        ILocation City { get; set; }
    }
}
