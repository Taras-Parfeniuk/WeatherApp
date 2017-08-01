using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Models.DTO
{
    public class HistoryEntry
    {
        public City City { get; set; }

        public DateTime QueryTime { get; set; }
        public List<SingleForecast> Forecasts { get; set; }
    }
}
