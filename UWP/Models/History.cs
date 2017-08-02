using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Uwp.Models.DTO;
using Uwp.Services;

namespace Uwp.Models
{
    public class History
    {
        public List<HistoryEntry> Entries { get; set; }

        public History()
        {
            _historyService = new HistoryService();
            Entries = new List<HistoryEntry>();
        }

        public async Task LoadEntries()
        {
            var entries = await _historyService.GetHistoryAsync();

            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
        }

        public async Task LoadEntriesByCity(string city)
        {
            var entries = await _historyService.GetHistoryByCityAsync(city);

            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
        }

        private HistoryService _historyService;
    }
}
