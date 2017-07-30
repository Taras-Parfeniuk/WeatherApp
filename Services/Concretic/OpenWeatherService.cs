using System;
using System.Net;
using System.IO;

using Domain.Entities.Abstraction;
using Services.Abstraction;

namespace Services.Concretic
{
    public class OpenWeatherService : BaseOpenWeatherService, IWeatherService
    { 
        public OpenWeatherService() : base()
        {
            _longForecastLenght = 7;
        }

        public IMultipleForecast MediumForecast(string city)
        {
            try
            {
                string uri = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&APPID={_APIKEY}";

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToMediumForecast(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMultipleForecast LongForecast(string city)
        {
            try
            {
                string uri = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={_longForecastLenght}&units=metric&APPID={_APIKEY}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToLongForecast(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMultipleForecast LongForecast(string city, int days)
        {
            if (days > 16 || days < 1)
                throw new ArgumentOutOfRangeException("days", "Days parameter must be in range 1..16.");

            try
            {
                string uri = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&cnt={days}&units=metric&APPID={_APIKEY}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToLongForecast(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ICurrentWeather CurrentWeather(string city)
        {
            string uri = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={_APIKEY}";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToCurrentWeather(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private int _longForecastLenght;
    }
}
