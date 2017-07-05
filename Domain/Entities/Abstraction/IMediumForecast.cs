using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Abstraction
{
    public interface IMediumForecast
    {
        ILocation City { get; set; }
        List<IShortForecast> HourForecasts { get; set; }
    }
}
