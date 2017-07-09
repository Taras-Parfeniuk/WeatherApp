using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IWeatherService
    {
        IMediumForecast MediumForecast(string city);
        ILongForecast LongForecast(string city);
        ICurrentWeather CurrentWeather(string city);
    }
}