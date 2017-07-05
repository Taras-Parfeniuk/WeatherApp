using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Forecast;

namespace Domain.Entities.Abstraction
{
    public interface ILongForecast
    {
        ILocation City { get; set; }
        List<IForecast> DayForecasts { get; set; }
    }
}
