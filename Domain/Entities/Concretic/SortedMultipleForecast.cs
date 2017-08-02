using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class SortedMultipleForecast
    {
        public City City { get; set; }
        public List<DayForecast> DayForecasts { get; set; }

        public SortedMultipleForecast(IMultipleForecast forecast)
        {
            City = forecast.City;
            DayForecasts = new List<DayForecast>();
            var days = forecast.SingleForecasts.GroupBy(f => f.ForecastTime.Date);

            foreach (var d in days)
            {
                var day = new DayForecast
                {
                    Date = d.Key,
                    Forecast = d.ToList()
                };
                DayForecasts.Add(day);
            }
        }
    }

    public class DayForecast
    {
        public DateTime Date { get; set; }
        public List<ISingleForecast> Forecast { get; set; }
    }
}
