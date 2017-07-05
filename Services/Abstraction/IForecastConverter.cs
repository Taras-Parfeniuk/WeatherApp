using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IForecastConverter
    {
        ICurrentWeather ToCurrentWeather(string json);
        ILongForecast ToLongForecast(string json);
        IMediumForecast ToMediumForecast(string json);
        IShortForecast ToShortForecast(string json);
        IForecast ToDefaultForecast(string json);
    }
}