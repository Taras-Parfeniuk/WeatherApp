using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IWeatherService
    {
        IMediumForecast MediumForecast(string city);
        ILongForecast LongForecast(string city);
        ILongForecast LongForecast(string city, int days);
        ICurrentWeather CurrentWeather(string city);
    }
}