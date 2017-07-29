using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;

using Newtonsoft.Json;

using UWP.Services.Abstraction;
using UWP.Models;

namespace UWP.Services.Concretic
{
    public class HistoryService : BaseService, IHistoryService
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
    }
}
