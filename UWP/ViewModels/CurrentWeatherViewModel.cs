using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

using Uwp.Models.DTO;
using Uwp.Models;

namespace Uwp.ViewModels
{
    public class CurrentWeatherViewModel : BaseForecastViewModel
    {
        public string Temperature { get; private set; }
        public string Sunset { get; private set; }
        public string Sunrise { get; private set; }
        public string WindSpeed { get; private set; }
        public string Humidity { get; private set; }
        public string Pressure { get; private set; }
        public string WeatherState { get; private set; }

        public CurrentWeatherViewModel(INavigationService navigationService) : base(navigationService)
        {
            Temperature = "";
            Sunrise = "";
            Sunrise = "";
            WindSpeed = "";
            Humidity = "";
            Pressure = "";

            MessengerInstance.Register<City>(this, city =>
            {
                _city = city;
                _model.SetCity(city);
                _model.LoadCurrentWeatherAsync(_instanceId);
                _model.ForecastLoaded += OnForecastLoad;
            });
        }

        private CurrentWeather _weather;

        override protected void OnForecastLoad(object sender, ForecastLoadedEventArgs e)
        {
            if (e.RecipientId == _instanceId)
            {
                _weather = _model.CurrentWeather;
                Title = $"{_weather.City.Name}, {_weather.City.Country} - {_weather.ForecastTime}";
                Temperature = $"{_weather.MinTemperature}C - {_weather.MaxTemperature}C";
                Sunrise = $"Sunrise at {_weather.Sunrise.TimeOfDay}";
                Sunset = $"Sunset at {_weather.Sunset.TimeOfDay}";
                WindSpeed = $"{_weather.WindSpeed} m/s";
                Humidity = $"{_weather.Humidity}%";
                Pressure = $"{_weather.DefaultPressure}";
                WeatherState = _weather.WeatherState;

                RaisePropertyChanged(() => WeatherState);
                RaisePropertyChanged(() => Temperature);
                RaisePropertyChanged(() => Humidity);
                RaisePropertyChanged(() => Pressure);
                RaisePropertyChanged(() => WindSpeed);
                RaisePropertyChanged(() => Sunrise);
                RaisePropertyChanged(() => Sunset);
            }
        }
    }
}
