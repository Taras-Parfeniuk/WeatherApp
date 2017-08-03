using Domain.Entities.Abstraction;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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

        Task<ISingleForecast> ToHourlyForecastAsync(JObject jObject);
        Task<ISingleForecast> ToHourlyForecastAsync(string json);
        Task<ICurrentWeather> ToCurrentWeatherAsync(string json);
        Task<ISingleForecast> ToDayForecastAsync(JObject jObject);
        Task<ISingleForecast> ToDayForecastAsync(string json);
        Task<IMultipleForecast> ToLongForecastAsync(string json);
        Task<IMultipleForecast> ToMediumForecastAsync(string json);
    }
}