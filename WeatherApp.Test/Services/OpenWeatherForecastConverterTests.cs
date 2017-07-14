using NUnit.Framework;

using Domain.Entities.Abstraction;
using Domain.Entities.Forecast;
using Domain.Entities.Location;
using Services.Concretic;
using Domain.Entities.Weather;
using System;
using System.Collections.Generic;

namespace WeatherApp.Test.Services
{
    [TestFixture]
    public class OpenWeatherForecastConverterTests
    {
        [Test]
        public void ToCurrentWeather_When_given_json_with_forecast_Then_return_correct_ICurrentWeather_object()
        {
            // Arrange
            var converter = new OpenWeatherForecastConverter();
            string json = "{\"coord\":{\"lon\":139,\"lat\":35},"
+ " \"sys\":{\"country\":\"JP\",\"sunrise\":1369769524,\"sunset\":1369821049},"
+ "\"weather\":[{\"id\":804,\"main\":\"clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],"
+ "\"main\":{\"temp\":289.5,\"humidity\":89,\"pressure\":1013,\"temp_min\":287.04,\"temp_max\":292.04},"
+ "\"wind\":{\"speed\":7.31,\"deg\":187.002},"
+ "\"rain\":{\"3h\":0},"
+ "\"clouds\":{\"all\":92},"
+ "\"dt\":1369824698,"
+ "\"id\":1851632,"
+ "\"name\":\"Shuzenji\","
+ "\"cod\":200}";
            ICurrentWeather expected = new CurrentDayForecast()
            {
                City = new City()
                {
                    Id = 1851632,
                    Coordinates = new Coordinates(139, 35),
                    Name = "Shuzenji",
                    Country = "JP"
                },
                Sunrise = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1369769524),
                Sunset = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1369821049),
                Cloudiness = 92,
                Rain = new Precipitation(0),
                MeathurementsTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1369824698),
                ForecastTime = DateTime.Now,
                MinTemperature = 287.04,
                MaxTemperature = 292.04,
                CurrentTemperature = 289.5,

                Wind = new Wind(7.31, 187),
                Weather = new WeatherState()
                {
                    Id = 804,
                    Description = "overcast clouds",
                    Main = "clouds",
                    Icon = "04n"
                },
                MainMeathurements = new Measurements()
                {
                    DefaultPressure = 1013,
                    Humidity = 89
                }
            };

            // Act
            ICurrentWeather obj = converter.ToCurrentWeather(json);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.City.Id, obj.City.Id);
                Assert.AreEqual(expected.City.Name, obj.City.Name);
                Assert.AreEqual(expected.City.Country, obj.City.Country);
                Assert.AreEqual(expected.City.Coordinates.Latitude, obj.City.Coordinates.Latitude);
                Assert.AreEqual(expected.City.Coordinates.Longitude, obj.City.Coordinates.Longitude);

            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.MainMeathurements.DefaultPressure, obj.MainMeathurements.DefaultPressure);
                Assert.AreEqual(expected.MainMeathurements.Humidity, obj.MainMeathurements.Humidity);
                Assert.AreEqual(expected.MainMeathurements.SeaLevelPressure, obj.MainMeathurements.SeaLevelPressure);
                Assert.AreEqual(expected.MainMeathurements.GroundLevelPressure, obj.MainMeathurements.GroundLevelPressure);
            });

            Assert.Multiple(() => 
            {
                Assert.AreEqual(expected.Weather.Id, obj.Weather.Id);
                Assert.AreEqual(expected.Weather.Main, obj.Weather.Main);
                Assert.AreEqual(expected.Weather.Icon, obj.Weather.Icon);
                Assert.AreEqual(expected.Weather.Description, obj.Weather.Description);
            });

            Assert.AreEqual(expected.Cloudiness, obj.Cloudiness);
            Assert.AreEqual(expected.CurrentTemperature, obj.CurrentTemperature);
            Assert.AreEqual(expected.MinTemperature, obj.MinTemperature);
            Assert.AreEqual(expected.MaxTemperature, obj.MaxTemperature);
            Assert.AreEqual(expected.Wind.Speed, obj.Wind.Speed);
            Assert.AreEqual(expected.Sunrise, obj.Sunrise);
            Assert.AreEqual(expected.Sunset, obj.Sunset);
            Assert.AreEqual(expected.Rain.LastHoursValue, obj.Rain.LastHoursValue);
        }

        [Test]
        public void ToShortForecast_When_given_json_with_forecast_Then_return_correct_IForecast_object()
        {
            // Arrange
            var converter = new OpenWeatherForecastConverter();
            string json = "{\"dt\":1485799200," 
                + "\"main\":{\"temp\":261.45,\"temp_min\":259.086,\"temp_max\":261.45,\"pressure\":1023.48,\"sea_level\":1045.39,\"grnd_level\":1023.48,\"humidity\":79,\"temp_kf\":2.37}," 
                + "\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"02n\"}],"
                + "\"clouds\":{\"all\":8},"
                + "\"wind\":{\"speed\":4.77,\"deg\":232.505},"
                + "\"snow\":{},"
                + "\"sys\":{\"pod\":\"n\"},"
                + "\"dt_txt\":\"2017 - 01 - 30 18:00:00\"}";

            IForecast expected = new DayForecast()
            {
                Cloudiness = 8,
                Wind = new Wind(4.77, 233),
                MinTemperature = 259.086,
                MaxTemperature = 261.45,
                Weather = new WeatherState()
                {
                    Id = 800,
                    Description = "clear sky",
                    Main = "Clear",
                    Icon = "02n"
                },
                MainMeathurements = new Measurements()
                {
                    DefaultPressure = 1023,
                    GroundLevelPressure = 1023,
                    SeaLevelPressure = 1045,
                    Humidity = 79
                },
                ForecastTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1485799200)
            };

            // Act
            IForecast obj = converter.ToShortForecast(json);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.MainMeathurements.DefaultPressure, obj.MainMeathurements.DefaultPressure);
                Assert.AreEqual(expected.MainMeathurements.Humidity, obj.MainMeathurements.Humidity);
                Assert.AreEqual(expected.MainMeathurements.SeaLevelPressure, obj.MainMeathurements.SeaLevelPressure);
                Assert.AreEqual(expected.MainMeathurements.GroundLevelPressure, obj.MainMeathurements.GroundLevelPressure);
            });

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Weather.Id, obj.Weather.Id);
                Assert.AreEqual(expected.Weather.Main, obj.Weather.Main);
                Assert.AreEqual(expected.Weather.Icon, obj.Weather.Icon);
                Assert.AreEqual(expected.Weather.Description, obj.Weather.Description);
            });

            Assert.AreEqual(expected.Cloudiness, obj.Cloudiness);
            Assert.AreEqual(expected.MinTemperature, obj.MinTemperature);
            Assert.AreEqual(expected.MaxTemperature, obj.MaxTemperature);
            Assert.AreEqual(expected.Wind.Speed, obj.Wind.Speed);
        }

        [Test]
        public void ToMediumForecast_When_given_json_with_forecast_Then_return_correct_IForecast_object()
        {
            // Arrange
            var converter = new OpenWeatherForecastConverter();

            string json_first_list_item = "{\"dt\":1485799200,"
                + "\"main\":{\"temp\":261.45,\"temp_min\":259.086,\"temp_max\":261.45,\"pressure\":1023.48,\"sea_level\":1045.39,\"grnd_level\":1023.48,\"humidity\":79,\"temp_kf\":2.37},"
                + "\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"02n\"}],"
                + "\"clouds\":{\"all\":8},"
                + "\"wind\":{\"speed\":4.77,\"deg\":232.505},"
                + "\"snow\":{},"
                + "\"sys\":{\"pod\":\"n\"},"
                + "\"dt_txt\":\"2017 - 01 - 30 18:00:00\"}";

            string json_second_list_item = "{\"dt\":1485810000,"
                + "\"main\":{\"temp\":261.41,\"temp_min\":259.638,\"temp_max\":261.41,\"pressure\":1022.41,\"sea_level\":1044.35,\"grnd_level\":1022.41,\"humidity\":76,\"temp_kf\":1.78},"
                + "\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],"
                + "\"clouds\":{\"all\":32},"
                + "\"wind\":{\"speed\":4.76,\"deg\":240.503},"
                + "\"snow\":{\"3h\":0.011},"
                + "\"sys\":{\"pod\":\"n\"},"
                + "\"dt_txt\":\"2017 - 01 - 30 21:00:00\"}";

            string json = "{\"city\":{\"id\":524901,\"name\":\"Moscow\",\"coord\":{\"lat\":55.7522,\"lon\":37.6156},\"country\":\"none\"},\"cod\":\"200\",\"message\":0.0036,\"cnt\":2,\"list\":["
                + json_first_list_item + ","
                + json_second_list_item
                + "]}";

            IMediumForecast expected = new FiveDaysForecast()
            {
                City = new City
                {
                    Id = 524901,
                    Name = "Moscow",
                    Country = "none",
                    Coordinates = new Coordinates(37.6156, 55.7522)
                },
                HourForecasts = new List<IForecast>() { converter.ToShortForecast(json_first_list_item), converter.ToShortForecast(json_second_list_item) }
            };

            // Act
            IMediumForecast obj = converter.ToMediumForecast(json);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.City.Id, obj.City.Id);
                Assert.AreEqual(expected.City.Name, obj.City.Name);
                Assert.AreEqual(expected.City.Country, obj.City.Country);
                Assert.AreEqual(expected.City.Coordinates.Latitude, obj.City.Coordinates.Latitude);
                Assert.AreEqual(expected.City.Coordinates.Longitude, obj.City.Coordinates.Longitude);

            });

            Assert.Multiple(() =>
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expected.HourForecasts[0].MainMeathurements.DefaultPressure, obj.HourForecasts[0].MainMeathurements.DefaultPressure);
                    Assert.AreEqual(expected.HourForecasts[0].MainMeathurements.Humidity, obj.HourForecasts[0].MainMeathurements.Humidity);
                    Assert.AreEqual(expected.HourForecasts[0].MainMeathurements.SeaLevelPressure, obj.HourForecasts[0].MainMeathurements.SeaLevelPressure);
                    Assert.AreEqual(expected.HourForecasts[0].MainMeathurements.GroundLevelPressure, obj.HourForecasts[0].MainMeathurements.GroundLevelPressure);
                });

                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expected.HourForecasts[0].Weather.Id, obj.HourForecasts[0].Weather.Id);
                    Assert.AreEqual(expected.HourForecasts[0].Weather.Main, obj.HourForecasts[0].Weather.Main);
                    Assert.AreEqual(expected.HourForecasts[0].Weather.Icon, obj.HourForecasts[0].Weather.Icon);
                    Assert.AreEqual(expected.HourForecasts[0].Weather.Description, obj.HourForecasts[0].Weather.Description);
                });

                Assert.AreEqual(expected.HourForecasts[0].Cloudiness, obj.HourForecasts[0].Cloudiness);
                Assert.AreEqual(expected.HourForecasts[0].MinTemperature, obj.HourForecasts[0].MinTemperature);
                Assert.AreEqual(expected.HourForecasts[0].MaxTemperature, obj.HourForecasts[0].MaxTemperature);
                Assert.AreEqual(expected.HourForecasts[0].Wind.Speed, obj.HourForecasts[0].Wind.Speed);
                Assert.AreEqual(expected.HourForecasts[0].Cloudiness, obj.HourForecasts[0].Cloudiness);
            }
            );

            Assert.Multiple(() =>
            {
                Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.HourForecasts[1].MainMeathurements.DefaultPressure, obj.HourForecasts[1].MainMeathurements.DefaultPressure);
                Assert.AreEqual(expected.HourForecasts[1].MainMeathurements.Humidity, obj.HourForecasts[1].MainMeathurements.Humidity);
                Assert.AreEqual(expected.HourForecasts[1].MainMeathurements.SeaLevelPressure, obj.HourForecasts[1].MainMeathurements.SeaLevelPressure);
                Assert.AreEqual(expected.HourForecasts[1].MainMeathurements.GroundLevelPressure, obj.HourForecasts[1].MainMeathurements.GroundLevelPressure);
            });

                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expected.HourForecasts[1].Weather.Id, obj.HourForecasts[1].Weather.Id);
                    Assert.AreEqual(expected.HourForecasts[1].Weather.Main, obj.HourForecasts[1].Weather.Main);
                    Assert.AreEqual(expected.HourForecasts[1].Weather.Icon, obj.HourForecasts[1].Weather.Icon);
                    Assert.AreEqual(expected.HourForecasts[1].Weather.Description, obj.HourForecasts[1].Weather.Description);
                });

                Assert.AreEqual(expected.HourForecasts[1].Cloudiness, obj.HourForecasts[1].Cloudiness);
                Assert.AreEqual(expected.HourForecasts[1].MinTemperature, obj.HourForecasts[1].MinTemperature);
                Assert.AreEqual(expected.HourForecasts[1].MaxTemperature, obj.HourForecasts[1].MaxTemperature);
                Assert.AreEqual(expected.HourForecasts[1].Wind.Speed, obj.HourForecasts[1].Wind.Speed);
                Assert.AreEqual(expected.HourForecasts[1].Cloudiness, obj.HourForecasts[1].Cloudiness);
            });
        }
    }
}
