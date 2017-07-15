using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class Forecast : BaseForecast, IDayForecast, IBaseForecast
    {
        public Guid Id { get; set; }

        public double? MorningTemperature { get; set; }
        public double? DayTemperature { get; set; }
        public double? EveningTemperature { get; set; }
        public double? CurrentTemperature { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }

        public Forecast() { }

        public Forecast(ICurrentWeather forecast)
        {
            Id = Guid.NewGuid();

            CurrentTemperature = forecast.CurrentTemperature;
            Sunrise = forecast.Sunrise;
            Sunset = forecast.Sunset;
            Cloudiness = forecast.Cloudiness;
            DefaultPressure = forecast.DefaultPressure;
            ForecastTime = forecast.ForecastTime;
            Humidity = forecast.Humidity;
            MaxTemperature = forecast.MaxTemperature;
            MinTemperature = forecast.MinTemperature;
            WindSpeed = forecast.WindSpeed;
            WeatherState = forecast.WeatherState;
            WeatherIcon = forecast.WeatherIcon;
            WeatherDescription = forecast.WeatherDescription;      
        }

        public Forecast(IBaseForecast forecast)
        {
            Id = Guid.NewGuid();

            Cloudiness = forecast.Cloudiness;
            DefaultPressure = forecast.DefaultPressure;
            ForecastTime = forecast.ForecastTime;
            Humidity = forecast.Humidity;
            MaxTemperature = forecast.MaxTemperature;
            MinTemperature = forecast.MinTemperature;
            WindSpeed = forecast.WindSpeed;
            WeatherState = forecast.WeatherState;
            WeatherIcon = forecast.WeatherIcon;
            WeatherDescription = forecast.WeatherDescription;
        }

        public Forecast(IDayForecast forecast)
        {
            Id = Guid.NewGuid();

            Cloudiness = forecast.Cloudiness;
            DefaultPressure = forecast.DefaultPressure;
            ForecastTime = forecast.ForecastTime;
            Humidity = forecast.Humidity;
            MaxTemperature = forecast.MaxTemperature;
            MinTemperature = forecast.MinTemperature;
            MorningTemperature = forecast.MorningTemperature;
            EveningTemperature = forecast.EveningTemperature;
            DayTemperature = forecast.DayTemperature;
            WindSpeed = forecast.WindSpeed;
            WeatherState = forecast.WeatherState;
            WeatherIcon = forecast.WeatherIcon;
            WeatherDescription = forecast.WeatherDescription;
        }
    }
}
