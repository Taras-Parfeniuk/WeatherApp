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

        public event SelectedCitiesLoadedEventHandler SelectedCitiesLoaded;

        public SelectedCities()
        {
            _citiesService = new CitiesService();
            Cities = new List<City>();
            LoadCities();
        }

        public async void LoadCities()
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

            SelectedCitiesLoaded(this, new SelectedCitiesLoadedEventArgs());
        }

        public async void Add(City city)
        {
            if (await _citiesService.AddToSelectedAsync(city))
            {
                LoadCities();
            }
        }

        public async void Add(string cityName)
        {
            var city = await _citiesService.GetByNameAsync(cityName);

            if (await _citiesService.AddToSelectedAsync(city))
            {
                LoadCities();
            }
        }

        public async void Remove(City city)
        {
            if (await _citiesService.RemoveFromSelectedAsync(city.Id))
            {
                LoadCities();
            }
        }

        public async void RemoveById(int id)
        {
            if (await _citiesService.RemoveFromSelectedAsync(id))
            {
                LoadCities();
            }
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

    public class SelectedCitiesLoadedEventArgs : EventArgs { }
    public delegate void SelectedCitiesLoadedEventHandler(object sender, SelectedCitiesLoadedEventArgs e);
}
