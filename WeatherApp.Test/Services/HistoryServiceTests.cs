using System;
using System.Collections.Generic;

using NUnit.Framework;
using Ninject;

using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;
using Services.Abstraction;
using Services.Concretic;
using Services.Util;

namespace WeatherApp.Test.Services
{
    [TestFixture]
    public class HistoryServiceTests
    {
        [Test]
        public void AddToHistory_GetEntryById_When_given_ICurrentForecast_object_Then_add_it_to_History_and_return_correct_added_entry()
        {
            // Arrange
            IKernel kernel = new StandardKernel(new ServicesNinjectModule());
            IHistoryService historyService = kernel.Get<IHistoryService>();
            ICurrentWeather input = new CurrentDayForecast()
            {
                City = new City()
                {
                    Id = 1851632,
                    Name = "Shuzenji",
                    Country = "JP"
                },
                Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1369769524),
                Sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1369821049),
                Cloudiness = 92,

                ForecastTime = DateTime.Now,
                MinTemperature = 287.04,
                MaxTemperature = 292.04,
                CurrentTemperature = 289.5,

                WindSpeed = 7.31,
                WeatherDescription = "overcast clouds",
                WeatherState = "clouds",
                WeatherIcon = "04n",

                DefaultPressure = 1013,
                Humidity = 89
            };
            ForecastQueryInfo expected = new ForecastQueryInfo()
            {
                City = input.City,
                Forecasts = new List<Forecast>() { new Forecast(input) }
            };

            // Act

            Guid id = historyService.AddToHistory(input);
            ForecastQueryInfo obj = historyService.GetEntryById(id);

            // Assert
            Forecast actualForecast = obj.Forecasts[0];
            Forecast expectedForecast = expected.Forecasts[0];

            Assert.AreEqual(expectedForecast.WeatherState, actualForecast.WeatherState);
            Assert.AreEqual(expectedForecast.WeatherIcon, actualForecast.WeatherIcon);
            Assert.AreEqual(expectedForecast.WeatherDescription, actualForecast.WeatherDescription);

            Assert.AreEqual(expectedForecast.Cloudiness, actualForecast.Cloudiness);
            Assert.AreEqual(expectedForecast.CurrentTemperature, actualForecast.CurrentTemperature);
            Assert.AreEqual(expectedForecast.MinTemperature, actualForecast.MinTemperature);
            Assert.AreEqual(expectedForecast.MaxTemperature, actualForecast.MaxTemperature);
            Assert.AreEqual(expectedForecast.WindSpeed, actualForecast.WindSpeed);
            Assert.AreEqual(expectedForecast.Sunrise, actualForecast.Sunrise);
            Assert.AreEqual(expectedForecast.Sunset, actualForecast.Sunset);
        }
    }
}
