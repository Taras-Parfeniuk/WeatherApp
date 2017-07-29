using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using UWP.Services.Abstraction;

namespace UWP.Models
{
    public class SelectedCities
    {
        public List<City> Cities { get; set; }

        public SelectedCities(ICitiesService service)
        {
            _citiesService = service;
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
        }

        public void Add(City city)
        {
            if (_citiesService.AddToSelectedAsync(city).Result)
            {
                LoadCities();
            }
        }

        public void Remove(City city)
        {
            if (_citiesService.RemoveFromSelectedAsync(city.Id).Result)
            {
                LoadCities();
            }
        }

        private ICitiesService _citiesService;
    }
}
