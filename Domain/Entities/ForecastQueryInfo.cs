using System;
using System.Collections.Generic;

using Domain.Entities.Location;
using Domain.Entities.Forecast;

namespace Domain.Entities
{
    public class ForecastQueryInfo
    {
        public Guid Id { get; set; }
        public DateTime QueryTime { get; set; }
        public City City { get; set; }

        public List<DayForecast> Forecasts { get; set; }

        public ForecastQueryInfo()
        {
            Forecasts = new List<DayForecast>();
        }
    }
}
