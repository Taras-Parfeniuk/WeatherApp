using System;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class StoredForecast : SingleForecast, ISingleForecast
    {
        public Guid Id { get; set; }

        public StoredForecast() { }

        public StoredForecast(ISingleForecast forecast)
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

            MorningTemperature = forecast.MorningTemperature;
            EveningTemperature = forecast.EveningTemperature;
            DayTemperature = forecast.DayTemperature;
        }
    }
}
