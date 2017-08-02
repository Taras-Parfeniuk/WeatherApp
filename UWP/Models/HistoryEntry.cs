using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uwp.Models.DTO;
using Uwp.Services;

namespace Uwp.Models
{
    public class HistoryEntry
    {
        public Guid Id { get; set; }
        public City City { get; set; }

        public DateTime QueryTime { get; set; }
        public List<SingleForecast> Forecasts { get; set; }

        public HistoryEntry()
        {
            _historyService = new HistoryService();
        }

        public async Task LoadForecasts()
        {
            var entry = await _historyService.GetEntryByIdAsync(Id);
            Forecasts = entry.Forecasts;
        }

        private HistoryService _historyService;
    }
}
