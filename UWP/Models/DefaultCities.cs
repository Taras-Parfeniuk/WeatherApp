using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Uwp.Models.DTO;
using Uwp.Services;

namespace Uwp.Models
{
    public class DefaultCities
    {
        public event DefaultCitiesLoadedEventHandler DefaultCitiesLoaded;

        private static DefaultCities _instance;

        private DefaultCities()
        {
            _citiesService = new CitiesService();
            Cities = new List<City>();
        }

        public static DefaultCities GetInstance()
        {
            if (_instance == null)
                _instance = new DefaultCities();
            return _instance;
        }

        public List<City> Cities { get; set; }

        public async Task<City> GetByNameAsync(string cityName)
        {
            return await _citiesService.GetByNameAsync(cityName);
        }

        public async void LoadCities()
        {
            var cities = await _citiesService.GetDefaultAsync();

            foreach (var city in cities)
            {
                Cities.Add(city);
            }

            DefaultCitiesLoaded(this, new DefaultCitiesLoadedEventArgs());
        }

        private CitiesService _citiesService;
    }

    public class DefaultCitiesLoadedEventArgs : EventArgs { }
    public delegate void DefaultCitiesLoadedEventHandler(object sender, DefaultCitiesLoadedEventArgs e);
}
