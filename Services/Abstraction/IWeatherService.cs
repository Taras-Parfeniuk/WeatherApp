using Domain.Entities.Abstraction;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IWeatherService
    {
        IMultipleForecast MediumForecast(string city);
        IMultipleForecast LongForecast(string city);
        IMultipleForecast LongForecast(string city, int days);
        ICurrentWeather CurrentWeather(string city);

        Task<IMultipleForecast> MediumForecastAsync(string city);
        Task<IMultipleForecast> LongForecastAsync(string city);
        Task<IMultipleForecast> LongForecastAsync(string city, int days);
        Task<ICurrentWeather> CurrentWeatherAsync(string city);
    }
}