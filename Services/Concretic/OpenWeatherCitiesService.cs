using System;
using System.Net;
using System.IO;

using Ninject;

using Services.Abstraction;
using Domain.Entities.Concretic;
using Domain.Data.Abstraction;
using System.Collections.Generic;

namespace Services.Concretic
{
    public class OpenWeatherCitiesService : BaseOpenWeatherService, ICitiesService
    {
        public OpenWeatherCitiesService() : base()
        {
            _selectedCities = _kernel.Get<ISelectedCitiesRepository>();
        }

        public City GetCityByName(string name)
        {
            string uri = $"http://api.openweathermap.org/data/2.5/weather?q={name}&units=metric&APPID={_APIKEY}";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToCurrentWeather(data).City;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public City GetCityById(int id)
        {
            string uri = $"http://api.openweathermap.org/data/2.5/weather?id={id}&units=metric&APPID={_APIKEY}";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToCurrentWeather(data).City;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddToSelected(City city)
        {
            _selectedCities.Add(city);
        }

        public List<City> GetSelected()
        {
            return _selectedCities.GetAll();
        }

        public void RemoveFromSelected(City city)
        {
            _selectedCities.Remove(city);
        }

        private ISelectedCitiesRepository _selectedCities;
    }
}
