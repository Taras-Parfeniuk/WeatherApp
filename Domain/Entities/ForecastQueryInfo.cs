using System;
using System.Linq;
using System.Collections.Generic;

using Domain.Entities.Abstraction;
using Domain.Entities.Location;
using Domain.Entities.Forecast;

namespace Domain.Entities
{
    public class ForecastQueryInfo
    {
        public Guid Id { get; set; }
        public DateTime QueryTime { get; set; }
        public City City { get; set; }

        public List<StoredForecast> Forecasts { get; set; }

        public ForecastQueryInfo()
        {
            Forecasts = new List<StoredForecast>();
        }

        public ForecastQueryInfo(IMediumForecast forecast)
        {
            Id = Guid.NewGuid();
            QueryTime = DateTime.Now;
            City = (City)forecast.City;
            Forecasts = new List<StoredForecast>(forecast.HourForecasts.Select(f => new StoredForecast(f)));
        }

        public ForecastQueryInfo(ILongForecast forecast)
        {
            Id = Guid.NewGuid();
            QueryTime = DateTime.Now;
            City = (City)forecast.City;
            Forecasts = new List<StoredForecast>(forecast.DayForecasts.Select(f => new StoredForecast(f)));
        }

        public ForecastQueryInfo(ICurrentWeather forecast)
        {
            Id = Guid.NewGuid();
            QueryTime = DateTime.Now;
            City = (City)forecast.City;
            Forecasts = new List<StoredForecast>() { new StoredForecast(forecast) };

        }
    }
}
