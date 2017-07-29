using System.Collections.Generic;
using System.Collections.ObjectModel;

using UWP.Services.Abstraction;

namespace UWP.Models
{
    public class DefaultCities
    {
        public List<City> Cities { get; set; }

        public DefaultCities(ICitiesService service)
        {
            _citiesService = service;
            Cities = new List<City>();
            LoadCities();
        }

        public async void LoadCities()
        {
            var cities = await _citiesService.GetDefaultAsync();

            foreach (var city in cities)
            {
                Cities.Add(city);
            }
        }

        private ICitiesService _citiesService;
    }
}
