using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;

namespace Domain.Entities.Abstraction
{
    public interface ILongForecast
    {
        City City { get; set; }
        List<IDayForecast> DayForecasts { get; set; }
    }
}
