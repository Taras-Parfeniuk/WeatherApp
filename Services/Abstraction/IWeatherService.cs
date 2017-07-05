using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IWeatherService
    {
        IMediumForecast MediumForecast { get; }
        ILongForecast LongForecast { get; }
        ICurrentWeather CurrentWeather { get; }
    }
}