using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Abstraction;

namespace Domain.Entities
{
    public class StoredForecast
    {
        public Guid Id { get; set; }
        public string Weather { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxTemperature { get; set; }
        public DateTime ForecastTime { get; set; }

        public Guid QueryId { get; set; }

        public StoredForecast(IForecast forecast)
        {
            Id = Guid.NewGuid();
            Weather = forecast.Weather.Main;
            MinTemperature = forecast.MinTemperature;
            MaxTemperature = forecast.MaxTemperature;
            ForecastTime = forecast.ForecastTime;
        }

        public StoredForecast() { }
    }
}
