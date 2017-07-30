using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class MultipleForecast : IMultipleForecast
    {
        public City City { get; set; }
        public List<ISingleForecast> SingleForecasts { get; set; }

        public MultipleForecast() { }

    }
}
