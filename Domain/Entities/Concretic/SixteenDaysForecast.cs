using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class SixteenDaysForecast : ILongForecast
    {
        public City City { get; set; }
        public List<IDayForecast> DayForecasts { get; set; }

        public SixteenDaysForecast() { }

    }
}
