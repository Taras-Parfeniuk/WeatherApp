using System;
using System.Collections.Generic;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class FiveDaysForecast : IMediumForecast
    {
        public City City { get; set; }
        public List<IBaseForecast> HourForecasts { get; set; }

        public FiveDaysForecast() { }
    }
}
