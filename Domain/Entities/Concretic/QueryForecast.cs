using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concretic
{
    public class QueryForecast
    {
        public City City { get; set; }
        public DateTime QueryTime { get; set; }
        public List<StoredForecast> Forecasts { get; set; }

        public QueryForecast()
        {
            Forecasts = new List<StoredForecast>();
        }
    }
}
