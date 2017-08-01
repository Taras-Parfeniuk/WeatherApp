using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Uwp.Services;
using Uwp.Models.DTO;

namespace Uwp.Models
{
    public class Forecasts
    {
        private static Forecasts _instance;

        private Forecasts()
        {
            _daysInDaily = 16;
            _forecastService = new ForecastService();
        }

        public static Forecasts GetInstance()
        {
            if (_instance == null)
                _instance = new Forecasts();
            return _instance;
        }

        public void SetCity(City city)
        {
            _city = city;
        }

        public CurrentWeather CurrentWeather
        {
            get
            {
                return _currentWeather;
            }
        }

        public MultipleForecast HourlyForecast
        {
            get
            {
                return _hourlyForecast;
            }
        }

        public MultipleForecast DailyForecast
        {
            get
            {
                return _dailyForecast;
            }
        }

        public event ForecastLoadedEventHandler ForecastLoaded;

        public async void LoadCurrentWeatherAsync(Guid recipientId)
        {
            _currentWeather = await _forecastService.GetCurrentWeatherByCity(_city.Name);
            ForecastLoaded(_currentWeather, new ForecastLoadedEventArgs(recipientId));
        }

        public async void LoadHourlyForecastAsync(Guid recipientId)
        {
            _hourlyForecast = await _forecastService.GetHourlyForecastByCity(_city.Name);
            ForecastLoaded(_hourlyForecast, new ForecastLoadedEventArgs(recipientId));
        }

        public async void LoadDailyForecastAsync(Guid recipientId)
        {
            _dailyForecast = await _forecastService.GetDailyForecastByCity(_city.Name, _daysInDaily);
            ForecastLoaded(_dailyForecast, new ForecastLoadedEventArgs(recipientId));
        }

        private CurrentWeather _currentWeather;
        private MultipleForecast _hourlyForecast;
        private MultipleForecast _dailyForecast;

        private ForecastService _forecastService;
        private City _city;
        private int _daysInDaily;
    }

    public class ForecastLoadedEventArgs : EventArgs
    {
        public Guid RecipientId { get; set; }

        public ForecastLoadedEventArgs(Guid recipientId) : base()
        {
            RecipientId = recipientId;
        }
    }
    public delegate void ForecastLoadedEventHandler(object sender, ForecastLoadedEventArgs e);
}
