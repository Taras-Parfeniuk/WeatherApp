using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Uwp.Services;
using Uwp.Models.DTO;

namespace Uwp.Models
{
    public class SelectedCities
    {
        public List<City> Cities { get; set; }

        public SelectedCities()
        {
            _citiesService = new CitiesService();
            Cities = new List<City>();
        }

        public async Task LoadCities()
        {
            if (Cities.Count > 0)
            {
                Cities.Clear();
            }

            var cities = await _citiesService.GetSelectedAsync();

            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        public async Task Add(City city)
        {
            await _citiesService.AddToSelectedAsync(city);
        }

        public async Task Add(string cityName)
        {
            var city = await _citiesService.GetByNameAsync(cityName);

            await _citiesService.AddToSelectedAsync(city);
        }

        public async Task Remove(City city)
        {
            await _citiesService.RemoveFromSelectedAsync(city.Id);
        }

        public async Task RemoveById(int id)
        {
            await _citiesService.RemoveFromSelectedAsync(id);
        }

        public async Task<City> GetByNameAsync(string cityName)
        {
            return await _citiesService.GetByNameAsync(cityName);
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _citiesService.GetByIdAsync(id);
        }

        private CitiesService _citiesService;
    }
}
