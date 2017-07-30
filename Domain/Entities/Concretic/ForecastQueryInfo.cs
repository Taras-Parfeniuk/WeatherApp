using System;
using System.Linq;
using System.Collections.Generic;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
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

        public ForecastQueryInfo(IMultipleForecast forecast)
        {
            QueryTime = DateTime.Now;
            City = forecast.City;
            Forecasts = new List<StoredForecast>(forecast.SingleForecasts.Select(f => f as StoredForecast));
        }

        public ForecastQueryInfo(ICurrentWeather forecast)
        {
            QueryTime = DateTime.Now;
            City = forecast.City;
            Forecasts = new List<StoredForecast>() { forecast as StoredForecast };
        }
    }
}
