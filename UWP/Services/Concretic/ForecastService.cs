using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using UWP.Services.Abstraction;
using UWP.Models;

namespace UWP.Services.Concretic
{
    public class ForecastService : BaseService, IForecastService
    {
        public async Task<MultipleForecast> GetHourlyForecastByCity(string cityName)
        {
            Uri resourceUri = new Uri(_APIURL + $"forecast/hourly?city={cityName}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MultipleForecast>(responseBody);
        }

        public async Task<MultipleForecast> GetDailyForecastByCity(string cityName, int days)
        {
            Uri resourceUri = new Uri(_APIURL + $"forecast/daily?city={cityName}&days={days}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MultipleForecast>(responseBody);
        }

        public async Task<CurrentWeather> GetCurrentWeatherByCity(string cityName)
        {
            Uri resourceUri = new Uri(_APIURL + $"forecast/current?city={cityName}");

            HttpResponseMessage response = await _httpClient.GetAsync(resourceUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            string responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CurrentWeather>(responseBody);
        }
    }
}
