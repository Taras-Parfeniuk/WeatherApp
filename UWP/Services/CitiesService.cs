using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Windows.Web.Http;

using Newtonsoft.Json;

using Uwp.Models.DTO;

namespace Uwp.Services
{
    public class CitiesService : BaseService
    {
        public async Task<List<City>> GetSelectedAsync()
        {
            Uri resourceUri = new Uri(_APIURL + "cities");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<City>>(responseBody);
        }

        public async Task<City> GetByNameAsync(string name)
        {
            Uri resourceUri = new Uri(_APIURL + $"cities?cityName={name}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<City>(responseBody);
        }

        public async Task<City> GetByIdAsync(int id)
        {
            Uri resourceUri = new Uri(_APIURL + $"cities/{id}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<City>(responseBody);
        }

        public async Task<bool> AddToSelectedAsync(City city)
        {
            Uri resourceUri = new Uri(_APIURL + $"cities");

            string requestBody = JsonConvert.SerializeObject(city);
            HttpStringContent content = new HttpStringContent(requestBody);
            HttpResponseMessage response = await _httpClient.PostAsync(resourceUri, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveFromSelectedAsync(int id)
        {
            Uri resourceUri = new Uri(_APIURL + $"cities/{id}");

            HttpResponseMessage response = await _httpClient.DeleteAsync(resourceUri);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<City>> GetDefaultAsync()
        {
            Uri resourceUri = new Uri(_APIURL + "cities/default");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<City>>(responseBody);
        }
    }
}
