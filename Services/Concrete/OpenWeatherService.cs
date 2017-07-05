using System.Net;
using System.IO;

using Domain.Entities.Abstraction;
using Domain.Entities.Location;
using Services.Abstraction;

namespace Services.Concrete
{
    public class OpenWeatherService : IWeatherService
    { 
        public ICurrentWeather CurrentWeather {
            get
            {
                string uri = $"http://api.openweathermap.org/data/2.5/weather?q={_city}&units=metric&APPID={_APIKEY}";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToCurrentWeather(data);
            }
        }

        public IMediumForecast MediumForecast {
            get
            {
                string uri = $"http://api.openweathermap.org/data/2.5/forecast?q={_city}&units=metric&APPID={_APIKEY}";

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToMediumForecast(data);
            }
        }
        public ILongForecast LongForecast {
            get
            {
                string uri = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={_city}&cnt={_longForecastLenght}&units=metric&APPID={_APIKEY}";

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data = string.Empty;

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    data = stream.ReadToEnd();
                }
                return _responseConverter.ToLongForecast(data);
            }
        }

        public OpenWeatherService(string cityName)
        {
            _city = cityName;
            _longForecastLenght = 5;
            _responseConverter = new OpenWeatherForecastConverter();
        }

        private string _city;
        private int _longForecastLenght;
        private const string _APIKEY = "9e37cc806b43d7a7425387e673677959";
        private IForecastConverter _responseConverter;
    }
}
