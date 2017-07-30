using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;

namespace Domain.Entities.Abstraction
{
    public interface IMultipleForecast
    {
        City City { get; set; }
        List<ISingleForecast> SingleForecasts { get; set; }
    }
}
