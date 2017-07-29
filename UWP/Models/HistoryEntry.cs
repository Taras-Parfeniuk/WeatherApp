using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Models
{
    public class HistoryEntry
    {
        public City City { get; set; }

        public DateTime Time { get; set; }
        public List<SingleForecast> Forecasts { get; set; }
    }
}
