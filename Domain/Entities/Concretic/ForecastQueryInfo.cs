using System;
using System.Linq;
using System.Collections.Generic;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class ForecastQueryInfo
    {
        public Guid Id { get; set; }

        public DateTime QueryTime { get; set; }
        public City City { get; set; }
    }
}
