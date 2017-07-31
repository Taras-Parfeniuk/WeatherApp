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

        public event HistoryEntriesLoadedEventHandler HistoryEntriesLoaded;

        public History()
        {
            _historyService = new HistoryService();
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
            HistoryEntriesLoaded(this, new HistoryEntriesLoadedEventArgs());
        }

        public async void LoadEntriesByCity(string city)
        {
            var entries = await _historyService.GetHistoryByCityAsync(city);

            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
            HistoryEntriesLoaded(this, new HistoryEntriesLoadedEventArgs());
        }

        private HistoryService _historyService;
    }

    public class HistoryEntriesLoadedEventArgs : EventArgs { }
    public delegate void HistoryEntriesLoadedEventHandler(object sender, HistoryEntriesLoadedEventArgs e);
}
