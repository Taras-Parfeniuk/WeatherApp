using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Abstraction
{
    public interface IMediumForecast
    {
        Guid Id { get; set; }

        ILocation City { get; set; }
        List<IForecast> HourForecasts { get; set; }
    }
}
