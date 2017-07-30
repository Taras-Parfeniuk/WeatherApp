using NUnit.Framework;

using Domain.Entities.Abstraction;
using Services.Concretic;

using System;
using System.Collections.Generic;
using Domain.Entities.Concretic;

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
            ICurrentWeather expected = new CurrentWeather()
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

            // Act
            ICurrentWeather obj = converter.ToCurrentWeather(json);

            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.City.Id, obj.City.Id);
                Assert.AreEqual(expected.City.Name, obj.City.Name);
                Assert.AreEqual(expected.City.Country, obj.City.Country);

            });

            Assert.AreEqual(expected.WeatherState, obj.WeatherState);
            Assert.AreEqual(expected.WeatherIcon, obj.WeatherIcon);
            Assert.AreEqual(expected.WeatherDescription, obj.WeatherDescription);

            Assert.AreEqual(expected.Cloudiness, obj.Cloudiness);
            Assert.AreEqual(expected.CurrentTemperature, obj.CurrentTemperature);
            Assert.AreEqual(expected.MinTemperature, obj.MinTemperature);
            Assert.AreEqual(expected.MaxTemperature, obj.MaxTemperature);
            Assert.AreEqual(expected.WindSpeed, obj.WindSpeed);
            Assert.AreEqual(expected.Sunrise, obj.Sunrise);
            Assert.AreEqual(expected.Sunset, obj.Sunset);
        }

        [Test]
        public void ToBaseForecast_When_given_json_with_forecast_Then_return_correct_IForecast_object()
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

            IBaseForecast expected = new BaseForecast()
            {
                Cloudiness = 8,
                WindSpeed = 4.77,
                MinTemperature = 259.086,
                MaxTemperature = 261.45,

                WeatherDescription = "clear sky",
                WeatherState = "Clear",
                WeatherIcon = "02n",

                DefaultPressure = 1023,
                Humidity = 79,

                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1485799200)
            };

            // Act
            IBaseForecast obj = converter.ToBaseForecast(json);

            //Assert

            Assert.AreEqual(expected.WeatherState, obj.WeatherState);
            Assert.AreEqual(expected.WeatherIcon, obj.WeatherIcon);
            Assert.AreEqual(expected.WeatherDescription, obj.WeatherDescription);

            Assert.AreEqual(expected.MinTemperature, obj.MinTemperature);
            Assert.AreEqual(expected.MaxTemperature, obj.MaxTemperature);

            Assert.AreEqual(expected.WindSpeed, obj.WindSpeed);
            Assert.AreEqual(expected.Cloudiness, obj.Cloudiness);
            Assert.AreEqual(expected.DefaultPressure, obj.DefaultPressure);
            Assert.AreEqual(expected.Humidity, obj.Humidity);
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
                },
                HourForecasts = new List<IBaseForecast>() { converter.ToBaseForecast(json_first_list_item), converter.ToBaseForecast(json_second_list_item) }
            };

            // Act
            IMediumForecast obj = converter.ToMediumForecast(json);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.City.Id, obj.City.Id);
                Assert.AreEqual(expected.City.Name, obj.City.Name);
                Assert.AreEqual(expected.City.Country, obj.City.Country);
            });

            for (var i = 0; i < 2; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expected.HourForecasts[i].WeatherState, obj.HourForecasts[i].WeatherState);
                    Assert.AreEqual(expected.HourForecasts[i].WeatherIcon, obj.HourForecasts[i].WeatherIcon);
                    Assert.AreEqual(expected.HourForecasts[i].WeatherDescription, obj.HourForecasts[i].WeatherDescription);
                });

                Assert.AreEqual(expected.HourForecasts[i].Cloudiness, obj.HourForecasts[i].Cloudiness);
                Assert.AreEqual(expected.HourForecasts[i].MinTemperature, obj.HourForecasts[i].MinTemperature);
                Assert.AreEqual(expected.HourForecasts[i].MaxTemperature, obj.HourForecasts[i].MaxTemperature);
                Assert.AreEqual(expected.HourForecasts[i].WindSpeed, obj.HourForecasts[i].WindSpeed);
                Assert.AreEqual(expected.HourForecasts[i].DefaultPressure, obj.HourForecasts[i].DefaultPressure);
                Assert.AreEqual(expected.HourForecasts[i].Humidity, obj.HourForecasts[i].Humidity);
            }
        }

        [Test]
        public void ToDayForecast_When_given_json_with_forecast_Then_return_correct_IForecast_object()
        {
            // Arrange
            var converter = new OpenWeatherForecastConverter();
            string json = "{\"dt\":1485766800," +
                "\"temp\":{\"day\":262.65,\"min\":261.41,\"max\":262.65,\"night\":261.41,\"eve\":262.65,\"morn\":262.65}," +
                "\"pressure\":1024.53," +
                "\"humidity\":76," +
                "\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"sky is clear\",\"icon\":\"01d\"}]," +
                "\"speed\":4.57,\"deg\":225," +
                "\"clouds\":0," +
                "\"snow\":0.01}";

            ISingleForecast expected = new SingleForecast()
            {
                DayTemperature = 262.65,
                MinTemperature = 261.41,
                MaxTemperature = 262.65,
                EveningTemperature = 262.65,
                MorningTemperature = 262.65,

                DefaultPressure = 1025,
                Humidity = 76,
                WeatherState = "Clear",
                WeatherDescription = "sky is clear",
                WeatherIcon = "01d",
                WindSpeed = 4.57,
                Cloudiness = 0,
                ForecastTime = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(1485766800)
            };

            // Act
            ISingleForecast obj = converter.ToDayForecast(json);

            // Assert
            Assert.AreEqual(expected.WeatherState, obj.WeatherState);
            Assert.AreEqual(expected.WeatherIcon, obj.WeatherIcon);
            Assert.AreEqual(expected.WeatherDescription, obj.WeatherDescription);

            Assert.AreEqual(expected.MinTemperature, obj.MinTemperature);
            Assert.AreEqual(expected.MaxTemperature, obj.MaxTemperature);
            Assert.AreEqual(expected.MorningTemperature, obj.MorningTemperature);
            Assert.AreEqual(expected.DayTemperature, obj.DayTemperature);
            Assert.AreEqual(expected.EveningTemperature, obj.EveningTemperature);

            Assert.AreEqual(expected.WindSpeed, obj.WindSpeed);
            Assert.AreEqual(expected.Cloudiness, obj.Cloudiness);
            Assert.AreEqual(expected.DefaultPressure, obj.DefaultPressure);
            Assert.AreEqual(expected.Humidity, obj.Humidity);
        }

        [Test]
        public void ToLongForecast_When_given_json_with_forecast_Then_return_correct_IForecast_object()
        {
            // Arrange
            var converter = new OpenWeatherForecastConverter();
            string json_first_list_item = "{\"dt\":1485766800," 
                + "\"temp\":{\"day\":262.65,\"min\":261.41,\"max\":262.65,\"night\":261.41,\"eve\":262.65,\"morn\":262.65}," 
                + "\"pressure\":1024.53," 
                + "\"humidity\":76," 
                + "\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"sky is clear\",\"icon\":\"01d\"}]," 
                + "\"speed\":4.57,\"deg\":225," 
                + "\"clouds\":0," 
                + "\"snow\":0.01}";

            string json_second_list_item = "{\"dt\":1485853200," 
                + "\"temp\":{\"day\":262.31,\"min\":260.98,\"max\":265.44,\"night\":265.44,\"eve\":264.18,\"morn\":261.46}," 
                + "\"pressure\":1018.1," 
                + "\"humidity\":91," 
                + "\"weather\":[{\"id\":600,\"main\":\"Snow\",\"description\":\"light snow\",\"icon\":\"13d\"}]," 
                + "\"speed\":4.1," 
                + "\"deg\":249," 
                + "\"clouds\":88," 
                + "\"snow\":1.44}";

            string json = "{\"cod\":\"200\"," 
                + "\"message\":0," 
                + "\"city\":{\"id\":524901,\"name\":\"Moscow\",\"lat\":55.7522,\"lon\":37.6156,\"country\":\"RU\",\"iso2\":\"RU\",\"type\":\"city\",\"population\":0}," 
                + "\"cnt\":2," 
                + "\"list\":[" 
                + json_first_list_item 
                + "," 
                + json_second_list_item
                + "]}";

            IMultipleForecast expected = new SixteenDaysForecast()
            {
                City = new City()
                {
                    Id = 524901,
                    Name = "Moscow",
                    Country = "RU"
                },

                DayForecasts = new List<ISingleForecast>() { converter.ToDayForecast(json_first_list_item), converter.ToDayForecast(json_second_list_item) }
            };

            // Act
            IMultipleForecast obj = converter.ToLongForecast(json);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.City.Id, obj.City.Id);
                Assert.AreEqual(expected.City.Name, obj.City.Name);
                Assert.AreEqual(expected.City.Country, obj.City.Country);
            });

            for(var i = 0; i < 2; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expected.DayForecasts[i].WeatherState, obj.DayForecasts[i].WeatherState);
                    Assert.AreEqual(expected.DayForecasts[i].WeatherIcon, obj.DayForecasts[i].WeatherIcon);
                    Assert.AreEqual(expected.DayForecasts[i].WeatherDescription, obj.DayForecasts[i].WeatherDescription);
                });

                Assert.AreEqual(expected.DayForecasts[i].MorningTemperature, obj.DayForecasts[i].MorningTemperature);
                Assert.AreEqual(expected.DayForecasts[i].DayTemperature, obj.DayForecasts[i].DayTemperature);
                Assert.AreEqual(expected.DayForecasts[i].EveningTemperature, obj.DayForecasts[i].EveningTemperature);
                Assert.AreEqual(expected.DayForecasts[i].MinTemperature, obj.DayForecasts[i].MinTemperature);
                Assert.AreEqual(expected.DayForecasts[i].MaxTemperature, obj.DayForecasts[i].MaxTemperature);

                Assert.AreEqual(expected.DayForecasts[i].Cloudiness, obj.DayForecasts[i].Cloudiness);
                Assert.AreEqual(expected.DayForecasts[i].WindSpeed, obj.DayForecasts[i].WindSpeed);
                Assert.AreEqual(expected.DayForecasts[i].DefaultPressure, obj.DayForecasts[i].DefaultPressure);
                Assert.AreEqual(expected.DayForecasts[i].Humidity, obj.DayForecasts[i].Humidity);
            }
        }
    }
}
