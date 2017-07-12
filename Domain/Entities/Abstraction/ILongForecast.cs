using System;
using System.Collections.Generic;

namespace Domain.Entities.Abstraction
{
    public interface ILongForecast
    {
        Guid Id { get; set; }

        ILocation City { get; set; }
        List<IForecast> DayForecasts { get; set; }
    }
}
