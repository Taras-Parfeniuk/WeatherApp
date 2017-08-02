using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;

using Newtonsoft.Json;

using Uwp.Models.DTO;
using Uwp.Models;

namespace Uwp.Services
{
    public class HistoryService : BaseService
    {
        public async Task<List<HistoryEntry>> GetHistoryAsync()
        {
            Uri resourceUri = new Uri(_APIURL + "history");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            List<HistoryEntry> entries = JsonConvert.DeserializeObject<List<HistoryEntry>>(responseBody);
            return entries;
        }

        public async Task<List<HistoryEntry>> GetHistoryByCityAsync(string cityName)
        {
            Uri resourceUri = new Uri(_APIURL + $"history?cityName={cityName}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            List<HistoryEntry> entries = JsonConvert.DeserializeObject<List<HistoryEntry>>(responseBody);
            return entries;
        }

        public async Task<HistoryEntry> GetEntryByIdAsync(Guid id)
        {
            Uri resourceUri = new Uri(_APIURL + $"history/{id}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            HistoryEntry entry = JsonConvert.DeserializeObject<HistoryEntry>(responseBody);
            return entry;
        }
    }
}
