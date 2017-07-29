using System.Collections.Generic;

using Domain.Entities.Concretic;

namespace Domain.Entities.Abstraction
{
    public interface IMediumForecast
    {
        City City { get; set; }
        List<IBaseForecast> HourForecasts { get; set; }
    }
}
