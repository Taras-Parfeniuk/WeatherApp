using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IWeatherService
    {
        IMultipleForecast MediumForecast(string city);
        IMultipleForecast LongForecast(string city);
        IMultipleForecast LongForecast(string city, int days);
        ICurrentWeather CurrentWeather(string city);
    }
}