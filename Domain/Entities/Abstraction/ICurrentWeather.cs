using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Temperature;
using Domain.Entities.Weather;

namespace Domain.Entities.Abstraction
{
    public interface ICurrentWeather
    {
        Precipitation Rain { get; set; }
        Precipitation Snow { get; set; }

        DateTime Sunrise { get; set; }
        DateTime Sunset { get; set; }
        ILocation City { get; set; }

        WeatherState Weather { get; set; }
        DefaultTemperature Temperature { get; set; }
        Measurements MainMeathurements { get; set; }
        Wind Wind { get; set; }
        double? Cloudiness { get; set; }
        DateTime MeathurementsTime { get; set; }
        DateTime ForecastTime { get; set; }
    }
}
