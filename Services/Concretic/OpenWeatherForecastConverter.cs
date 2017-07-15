using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Services.Abstraction;
using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;

namespace Services.Concretic
{
    public class OpenWeatherForecastConverter : IForecastConverter
    {
        public ICurrentWeather ToCurrentWeather(string json)
        {
            var jObject = JObject.Parse(json);

            return new CurrentDayForecast()
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
                
                Sunrise = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunrise"]),
                Sunset = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunset"]),

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],


                ForecastTime = DateTime.Now
            };
        }

        public IMediumForecast ToMediumForecast(string json)
        {
            var jObject = JObject.Parse(json);

            var forecast = new FiveDaysForecast()
            {
                City = new City
                {
                    Id = (int)jObject["city"]["id"],
                    Name = (string)jObject["city"]["name"],
                    Country = (string)jObject["city"]["country"],
                },
                HourForecasts = new List<IBaseForecast>()
            };

            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.HourForecasts.Add(ToBaseForecast((JObject)jObject["list"][i]));
            }

            return forecast;
        }

        public ILongForecast ToLongForecast(string json)
        {
            var jObject = JObject.Parse(json);

            var forecast = new SixteenDaysForecast()
            {
                City = new City
                {
                    Id = (int)jObject["city"]["id"],
                    Name = (string)jObject["city"]["name"],
                    Country = (string)jObject["city"]["country"],
                },
                DayForecasts = new List<IDayForecast>()
            };
            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.DayForecasts.Add(ToDayForecast((JObject)jObject["list"][i]));
            }

            return forecast;
        }

        public IBaseForecast ToBaseForecast(JObject jObject)
        {
            return new BaseForecast
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

                ForecastTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"])
            };
        }

        public IBaseForecast ToBaseForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToBaseForecast(jObject);
        }

        public IDayForecast ToDayForecast(JObject jObject)
        {
            return new DayForecast()
            {
                Humidity = (int?)jObject["humidity"],
                DefaultPressure = (int?)jObject["pressure"],
                Cloudiness = (double?)jObject["clouds"],
                ForecastTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"]),
                WindSpeed = (double?)jObject["speed"],

                WeatherIcon = (string)jObject["weather"][0]["icon"],
                WeatherState = (string)jObject["weather"][0]["main"],
                WeatherDescription = (string)jObject["weather"][0]["description"],

                MinTemperature = (double?)jObject["temp"]["temp_min"],
                MaxTemperature = (double?)jObject["temp"]["temp_max"],
                DayTemperature = (double?)jObject["temp"]["day"],
                EveningTemperature = (double?)jObject["temp"]["eve"],
                MorningTemperature = (double?)jObject["temp"]["morn"]    
            };
        }

        public IDayForecast ToDayForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToDayForecast(jObject);
        }
    }
}
