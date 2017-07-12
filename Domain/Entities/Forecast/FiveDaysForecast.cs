using System;
using System.Collections.Generic;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class FiveDaysForecast : IMediumForecast
    {
        public Guid Id { get; set; }

        public ILocation City { get; set; }
        public List<IForecast> HourForecasts { get; set; }

        public FiveDaysForecast()
        {
            Id = Guid.NewGuid();
        }
    }
}
