using System.Net;
using System.IO;

using Domain.Entities.Abstraction;
using Domain.Entities.Location;
using Domain.Data;
using Services.Abstraction;

namespace Services.Concrete
{
    public class OpenWeatherService : IWeatherService
    { 
        public ILocation City { get; set; }

        public ICurrentWeather CurrentWeather {
            get
            {
                string uri = "http://api.openweathermap.org/data/2.5/forecast/daily?" + (City.Id < 0 ? "q=" + ((City)City).Name : "id=" + City.Id.ToString()) + $"&units=metric&APPID={_APIKEY}";
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
                string uri = "http://api.openweathermap.org/data/2.5/forecast?" 
                    + (City.Id < 0 ? "q=" + ((City)City).Name : "id=" 
                    + City.Id.ToString()) 
                    + $"&units=metric&APPID={_APIKEY}";

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
                string uri = "http://api.openweathermap.org/data/2.5/forecast/daily?&cnt={cnt}" 
                    + (City.Id < 0 ? "q=" 
                    + ((City)City).Name : "id=" 
                    + City.Id.ToString()) 
                    + $"&cnt={_longForecastLenght}&units=metric&APPID={_APIKEY}";

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
            ICityRepository cities = new CityRepository();
            City = cities.GetCityByName(cityName);

            if (City == null)
                City = new City()
                {
                    Id = -1,
                    Name = cityName,
                    Coordinates = new Coordinates(-1, -1),
                    Country = string.Empty
                };

            _longForecastLenght = 5;
            _responseConverter = new OpenWeatherForecastConverter();
        }

        private int _longForecastLenght;
        private const string _APIKEY = "9e37cc806b43d7a7425387e673677959";
        private IForecastConverter _responseConverter;
    }
}
