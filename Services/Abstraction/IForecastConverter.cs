using Domain.Entities.Abstraction;
using Newtonsoft.Json.Linq;

namespace Services.Abstraction
{
    public interface IForecastConverter
    {
        IBaseForecast ToBaseForecast(JObject jObject);
        IBaseForecast ToBaseForecast(string json);
        ICurrentWeather ToCurrentWeather(string json);
        IDayForecast ToDayForecast(JObject jObject);
        IDayForecast ToDayForecast(string json);
        ILongForecast ToLongForecast(string json);
        IMediumForecast ToMediumForecast(string json);
    }
}