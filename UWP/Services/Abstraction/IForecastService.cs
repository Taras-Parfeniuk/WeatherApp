using System.Threading.Tasks;

using UWP.Models;

namespace UWP.Services.Abstraction
{
    public interface IForecastService
    {
        Task<MultipleForecast> GetHourlyForecastByCity(string cityName);
        Task<MultipleForecast> GetDailyForecastByCity(string cityName, int days);
        Task<CurrentWeather> GetCurrentWeatherByCity(string cityName);
    }
}