using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Services.Abstraction;
using Domain.Entities.Location;
using System.Net;
using System.IO;

namespace Services.Concretic
{
    public class OpenWeatherCitiesService : ICitiesService
    {
        public OpenWeatherCitiesService()
        {
            _responseConverter = new OpenWeatherForecastConverter();
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
                return (City)_responseConverter.ToCurrentWeather(data).City;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private const string _APIKEY = "9e37cc806b43d7a7425387e673677959";
        private IForecastConverter _responseConverter;
    }
}
