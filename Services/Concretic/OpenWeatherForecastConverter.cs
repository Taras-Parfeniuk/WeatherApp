﻿using System;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using Services.Abstraction;
using Domain.Entities.Abstraction;
using Domain.Entities.Forecast;
using Domain.Entities.Location;
using Domain.Entities.Weather;

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
                    Coordinates = new Coordinates((double?)jObject["coord"]["lon"], (double?)jObject["coord"]["lat"]) 
                },
                Cloudiness = (double?)jObject["clouds"]["all"],
                Rain = new Precipitation((int?)jObject["rain"]?["3h"]),
                Snow = new Precipitation((int?)jObject["snow"]?["3h"]),
                MeathurementsTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"]),
                ForecastTime = DateTime.Now,
                MinTemperature = (double?)jObject["main"]["temp_min"],
                MaxTemperature = (double?)jObject["main"]["temp_max"],
                CurrentTemperature = (double?)jObject["main"]["temp"],
                
                Wind = new Wind((double?)jObject["wind"]["speed"], (int?)jObject["deg"]),
                Sunrise = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunrise"]),
                Sunset = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["sys"]["sunset"]),
                Weather = new WeatherState()
                {
                    Id = (int?)jObject["weather"][0]["id"],
                    Description = (string)jObject["weather"][0]["description"],
                    Main = (string)jObject["weather"][0]["main"],
                    Icon = (string)jObject["weather"][0]["icon"]
                },
                MainMeathurements = new Measurements()
                {
                    DefaultPressure = (int?)jObject["main"]["pressure"],
                    GroundLevelPressure = (int?)jObject["main"]["grnd_level"],
                    SeaLevelPressure = (int?)jObject["main"]["sea_level"],
                    Humidity = (int?)jObject["main"]["humidity"]
                }
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
                    Coordinates = new Coordinates((double)jObject["city"]["coord"]["lon"], (double)jObject["city"]["coord"]["lat"])
                },
                HourForecasts = new List<IForecast>()
            };

            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.HourForecasts.Add(ToShortForecast((JObject)jObject["list"][i]));
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
                    Coordinates = new Coordinates((double)jObject["city"]["coord"]["lon"], (double)jObject["city"]["coord"]["lat"])
                },
                DayForecasts = new List<IForecast>()
            };
            for (var i = 0; i < (int)jObject["cnt"]; i++)
            {
                forecast.DayForecasts.Add(ToDayForecast((JObject)jObject["list"][i]));
            }

            return forecast;
        }

        public IForecast ToShortForecast(JObject jObject)
        {
            return new DayForecast()
            {
                Cloudiness = (double?)jObject["clouds"]["all"],
                Rain = new Precipitation((int?)jObject["rain"]?["3h"]),
                Snow = new Precipitation((int?)jObject["snow"]?["3h"]),
                Wind = new Wind((double?)jObject["wind"]["speed"], (int?)jObject["wind"]["deg"]),
                MinTemperature = (double?)jObject["main"]["temp_min"],
                MaxTemperature = (double?)jObject["main"]["temp_max"],
                Weather = new WeatherState()
                {
                    Id = (int?)jObject["weather"][0]["id"],
                    Description = (string)jObject["weather"][0]["description"],
                    Main = (string)jObject["weather"][0]["main"],
                    Icon = (string)jObject["weather"][0]["icon"]
                },
                MainMeathurements = new Measurements()
                {
                    DefaultPressure = (int?)jObject["main"]["pressure"],
                    GroundLevelPressure = (int?)jObject["main"]["grnd_level"],
                    SeaLevelPressure = (int?)jObject["main"]["sea_level"],
                    Humidity = (int?)jObject["main"]["humidity"]
                },
                ForecastTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"])
            };
        }

        public IForecast ToShortForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToShortForecast(jObject);
        }

        public IForecast ToDayForecast(JObject jObject)
        {
            return new DayForecast()
            {
                Cloudiness = (double?)jObject["clouds"],
                ForecastTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)jObject["dt"]),
                MeathurementsTime = DateTime.Today,
                Wind = new Wind((double?)jObject["speed"], (int?)jObject["deg"]),
                Weather = new WeatherState()
                {
                    Id = (int?)jObject["weather"][0]["id"],
                    Description = (string)jObject["weather"][0]["description"],
                    Main = (string)jObject["weather"][0]["main"],
                    Icon = (string)jObject["weather"][0]["icon"]
                },
                MinTemperature = (double?)jObject["temp"]["temp_min"],
                MaxTemperature = (double?)jObject["temp"]["temp_max"],
                DayTemperature = (double?)jObject["temp"]["day"],
                EveningTemperature = (double?)jObject["temp"]["eve"],
                MorningTemperature = (double?)jObject["temp"]["morn"],
                
                MainMeathurements = new Measurements()
                {
                    Humidity = (int?)jObject["humidity"],
                    SeaLevelPressure = (int?)jObject["pressure"]
                }
            };
        }

        public IForecast ToDayForecast(string json)
        {
            var jObject = JObject.Parse(json);

            return ToDayForecast(jObject);
        }
    }
}
