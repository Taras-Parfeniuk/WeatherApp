using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UWP.Services.Abstraction;

namespace UWP.Models
{
    public class History
    {
        public List<HistoryEntry> Entries { get; set; }

        public History(IHistoryService service)
        {
            _historyService = service;
            Entries = new List<HistoryEntry>();
            LoadEntries();
        }

        public async void LoadEntries()
        {
            var entries = await _historyService.GetHistoryAsync();

            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
        }

        private IHistoryService _historyService;
    }
}
