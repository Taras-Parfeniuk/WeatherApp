using System.Collections.Generic;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class FiveDaysForecast : IMediumForecast
    {
        public ILocation City { get; set; }
        public List<IShortForecast> HourForecasts { get; set; }
    }
}
