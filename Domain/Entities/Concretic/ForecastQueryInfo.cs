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

        public List<Forecast> Forecasts { get; set; }

        public ForecastQueryInfo()
        {
            Forecasts = new List<Forecast>();
        }

        public ForecastQueryInfo(IMediumForecast forecast)
        {
            QueryTime = DateTime.Now;
            City = forecast.City;
            Forecasts = new List<Forecast>(forecast.HourForecasts.Select(f => f as Forecast));
        }

        public ForecastQueryInfo(ILongForecast forecast)
        {
            QueryTime = DateTime.Now;
            City = forecast.City;
            Forecasts = new List<Forecast>(forecast.DayForecasts.Select(f => f as Forecast));
        }

        public ForecastQueryInfo(ICurrentWeather forecast)
        {
            QueryTime = DateTime.Now;
            City = forecast.City;
            Forecasts = new List<Forecast>() { forecast as Forecast };
        }
    }
}
