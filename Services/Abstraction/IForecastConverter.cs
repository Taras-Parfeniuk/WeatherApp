using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IForecastConverter
    {
        ICurrentWeather ToCurrentWeather(string json);
        ILongForecast ToLongForecast(string json);
        IMediumForecast ToMediumForecast(string json);
        IForecast ToShortForecast(string json);
        IForecast ToDayForecast(string json);
    }
}