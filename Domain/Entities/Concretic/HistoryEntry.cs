using System;
using System.Collections.Generic;

namespace Domain.Entities.Concretic
{
    public class HistoryEntry
    {
        public Guid Id { get; set; }
        public int CityId { get; set; }
        
        public DateTime Time { get; set; }
        public List<StoredForecast> Forecasts { get; set; }

        public HistoryEntry()
        {
            Forecasts = new List<StoredForecast>();
        }
    }
}
