using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Services.Abstraction;
using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;
using Services.Exceptions;
using System.Threading.Tasks;

namespace Services.Concretic
{
    public class OpenWeatherForecastConverter : IForecastConverter
    {
        public ICurrentWeather ToCurrentWeather(string json)
        {
            var jObject = JObject.Parse(json);
            var statusCode = (int)jObject["cod"];

            switch (statusCode)
            {
                case 200:
                    break;
                case 404:
                    throw new CityNotFoundException((string)jObject["message"]);
                default:
                    throw new Exception();
            }

            return new CurrentWeather()
            {
                City = new City()
                {
                    Id = (int)jObject["id"],
                    Name = (string)jObject["name"],
                    Country = (string)jObject["sys"]["country"],
                },

                DefaultPressure = (int?)jObject["main"]["pressure"],
                Humidity = (int?)jObject["main"]["humidity"],
                Cloudiness = (double?)jObject["clouds"]["all"],
                WindSpeed = (double?)jObject["wind"]["speed"],

                MinTemperature = (double?)jObject["main"]["temp_min"],
                MaxTemperature = (double?)jObject["main"]["temp_max"],
                CurrentTemperature = (double?)jObject["main"]["temp"],
                
                Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunrise"]),
                Sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunset"]),

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],


                ForecastTime = DateTime.Now
            };
        }

        public IMultipleForecast ToMediumForecast(string json)
        {
            var jObject = JObject.Parse(json);
            var statusCode = (int)jObject["cod"];

            switch (statusCode)
            {
                case 200:
                    break;
                case 404:
                    throw new CityNotFoundException((string)jObject["message"]);
                default:
                    throw new Exception();
            }

            var forecast = new MultipleForecast()
            {
                City = new City
                {
                    Id = (int)jObject["city"]["id"],
                    Name = (string)jObject["city"]["name"],
                    Country = (string)jObject["city"]["country"],
                },
                SingleForecasts = new List<ISingleForecast>()
            };

            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.SingleForecasts.Add(ToHourlyForecast((JObject)jObject["list"][i]));
            }

            return forecast;
        }

        public IMultipleForecast ToLongForecast(string json)
        {
            var jObject = JObject.Parse(json);
            var statusCode = (int)jObject["cod"];

            switch (statusCode)
            {
                case 200:
                    break;
                case 404:
                    throw new CityNotFoundException((string)jObject["message"]);
                default:
                    throw new Exception();
            }

            var forecast = new MultipleForecast()
            {
                City = new City
                {
                    Id = (int)jObject["city"]["id"],
                    Name = (string)jObject["city"]["name"],
                    Country = (string)jObject["city"]["country"],
                },
                SingleForecasts = new List<ISingleForecast>()
            };
            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.SingleForecasts.Add(ToDayForecast((JObject)jObject["list"][i]));
            }

            return forecast;
        }

        public ISingleForecast ToHourlyForecast(JObject jObject)
        {
            return new SingleForecast
            {
                DefaultPressure = (int?)jObject["main"]["pressure"],
                Humidity = (int?)jObject["main"]["humidity"],
                Cloudiness = (double?)jObject["clouds"]["all"],
                WindSpeed = (double?)jObject["wind"]["speed"],

                MinTemperature = (double?)jObject["main"]["temp_min"],
                MaxTemperature = (double?)jObject["main"]["temp_max"],

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],

                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"])
            };
        }

        public ISingleForecast ToHourlyForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToHourlyForecast(jObject);
        }

        public ISingleForecast ToDayForecast(JObject jObject)
        {
            return new SingleForecast()
            {
                Humidity = (int?)jObject["humidity"],
                DefaultPressure = (int?)jObject["pressure"],
                Cloudiness = (double?)jObject["clouds"],
                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"]),
                WindSpeed = (double?)jObject["speed"],

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],

                MinTemperature = (double?)jObject["temp"]["min"],
                MaxTemperature = (double?)jObject["temp"]["max"],
                DayTemperature = (double?)jObject["temp"]["day"],
                EveningTemperature = (double?)jObject["temp"]["eve"],
                MorningTemperature = (double?)jObject["temp"]["morn"]    
            };
        }

        public ISingleForecast ToDayForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToDayForecast(jObject);
        }

        public async Task<ISingleForecast> ToHourlyForecastAsync(JObject jObject)
        {
            return await Task.Run(() => new SingleForecast
            {
                DefaultPressure = (int?)jObject["main"]["pressure"],
                Humidity = (int?)jObject["main"]["humidity"],
                Cloudiness = (double?)jObject["clouds"]["all"],
                WindSpeed = (double?)jObject["wind"]["speed"],

                MinTemperature = (double?)jObject["main"]["temp_min"],
                MaxTemperature = (double?)jObject["main"]["temp_max"],

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],

                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"])
            });
        }

        public async Task<ISingleForecast> ToHourlyForecastAsync(string json)
        {
            var jObject = JObject.Parse(json);

            return await ToHourlyForecastAsync(jObject);
        }

        public async Task<ICurrentWeather> ToCurrentWeatherAsync(string json)
        {
            return await Task.Run(() => {
                var jObject = JObject.Parse(json);
                var statusCode = (int)jObject["cod"];

                switch (statusCode)
                {
                    case 200:
                        break;
                    case 404:
                        throw new CityNotFoundException((string)jObject["message"]);
                    default:
                        throw new Exception();
                }

                return new CurrentWeather()
                {
                    City = new City()
                    {
                        Id = (int)jObject["id"],
                        Name = (string)jObject["name"],
                        Country = (string)jObject["sys"]["country"],
                    },

                    DefaultPressure = (int?)jObject["main"]["pressure"],
                    Humidity = (int?)jObject["main"]["humidity"],
                    Cloudiness = (double?)jObject["clouds"]["all"],
                    WindSpeed = (double?)jObject["wind"]["speed"],

                    MinTemperature = (double?)jObject["main"]["temp_min"],
                    MaxTemperature = (double?)jObject["main"]["temp_max"],
                    CurrentTemperature = (double?)jObject["main"]["temp"],

                    Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunrise"]),
                    Sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunset"]),

                    WeatherIcon = (string)jObject["weather"][0]["icon"],
                    WeatherState = (string)jObject["weather"][0]["main"],
                    WeatherDescription = (string)jObject["weather"][0]["description"],


                    ForecastTime = DateTime.Now
                };
            });
        }

        public async Task<ISingleForecast> ToDayForecastAsync(JObject jObject)
        {
            return await Task.Run(() => new SingleForecast()
            {
                Humidity = (int?)jObject["humidity"],
                DefaultPressure = (int?)jObject["pressure"],
                Cloudiness = (double?)jObject["clouds"],
                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"]),
                WindSpeed = (double?)jObject["speed"],

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],

                MinTemperature = (double?)jObject["temp"]["min"],
                MaxTemperature = (double?)jObject["temp"]["max"],
                DayTemperature = (double?)jObject["temp"]["day"],
                EveningTemperature = (double?)jObject["temp"]["eve"],
                MorningTemperature = (double?)jObject["temp"]["morn"]
            });
        }

        public async Task<ISingleForecast> ToDayForecastAsync(string json)
        {
            var jObject = JObject.Parse(json);

            return await ToDayForecastAsync(jObject);
        }

        public async Task<IMultipleForecast> ToLongForecastAsync(string json)
        {
            return await Task.Run(() => {
                var jObject = JObject.Parse(json);
                var statusCode = (int)jObject["cod"];

                switch (statusCode)
                {
                    case 200:
                        break;
                    case 404:
                        throw new CityNotFoundException((string)jObject["message"]);
                    default:
                        throw new Exception();
                }

                var forecast = new MultipleForecast()
                {
                    City = new City
                    {
                        Id = (int)jObject["city"]["id"],
                        Name = (string)jObject["city"]["name"],
                        Country = (string)jObject["city"]["country"],
                    },
                    SingleForecasts = new List<ISingleForecast>()
                };
                for (var i = 0; i < (int)jObject["cnt"]; i++)
                {
                    forecast.SingleForecasts.Add(ToDayForecast((JObject)jObject["list"][i]));
                }

                return forecast;
            });          
        }

        public async Task<IMultipleForecast> ToMediumForecastAsync(string json)
        {
            return await Task.Run(() => {
                var jObject = JObject.Parse(json);
                var statusCode = (int)jObject["cod"];

                switch (statusCode)
                {
                    case 200:
                        break;
                    case 404:
                        throw new CityNotFoundException((string)jObject["message"]);
                    default:
                        throw new Exception();
                }

                var forecast = new MultipleForecast()
                {
                    City = new City
                    {
                        Id = (int)jObject["city"]["id"],
                        Name = (string)jObject["city"]["name"],
                        Country = (string)jObject["city"]["country"],
                    },
                    SingleForecasts = new List<ISingleForecast>()
                };

                for (var i = 0; i < (int)jObject["cnt"]; i++)
                {
                    forecast.SingleForecasts.Add(ToHourlyForecast((JObject)jObject["list"][i]));
                }

                return forecast;
            });
        }
    }
}
