using Domain.Entities.Abstraction;
using Newtonsoft.Json.Linq;

namespace Services.Abstraction
{
    public interface IForecastConverter
    {
        ISingleForecast ToHourlyForecast(JObject jObject);
        ISingleForecast ToHourlyForecast(string json);
        ICurrentWeather ToCurrentWeather(string json);
        ISingleForecast ToDayForecast(JObject jObject);
        ISingleForecast ToDayForecast(string json);
        IMultipleForecast ToLongForecast(string json);
        IMultipleForecast ToMediumForecast(string json);
    }
}