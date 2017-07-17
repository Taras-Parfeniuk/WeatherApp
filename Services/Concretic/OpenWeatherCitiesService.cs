using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

using Ninject;

using Services.Abstraction;
using Domain.Entities.Concretic;
using Domain.Data.Abstraction;
using Domain.Exceptions;


namespace Services.Concretic
{
    public class OpenWeatherCitiesService : BaseOpenWeatherService, ICitiesService
    {
        public OpenWeatherCitiesService(ISelectedCitiesRepository selectedCities) : base()
        {
            _selectedCities = selectedCities;
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

        public void UpdateInSelected(City city)
        {
            try
            {
                _selectedCities.Update(city);
            }
            catch(ItemNotExistException ex)
            {
                throw ex;
            }
        }

        public void AddToSelected(City city)
        {
            try
            {
                _selectedCities.Add(city);
            }
            catch(ItemAlreadyExistException ex)
            {
                throw ex;
            }
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
