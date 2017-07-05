using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Temperature;
using Domain.Entities.Weather;

namespace Domain.Entities.Abstraction
{
    public interface IShortForecast : IForecast
    {
        Precipitation Rain { get; set; }
        Precipitation Snow { get; set; }
    }
}
