using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Forecast
{
    public class SixteenDaysForecast : ILongForecast
    {
        public ILocation City { get; set; }
        public List<IForecast> DayForecasts { get; set; }

    }
}
