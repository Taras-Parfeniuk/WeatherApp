using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Weather;
using Domain.Entities.Temperature;

namespace Domain.Entities.Abstraction
{
    public interface IForecast
    {
        Guid Id { get; set; }

        WeatherState Weather { get; set; }
        DefaultTemperature Temperature { get; set; }
        Measurements MainMeathurements { get; set; }
        Wind Wind { get; set; }
        double? Cloudiness { get; set; }
        DateTime MeathurementsTime { get; set; }
        DateTime ForecastTime { get; set; }

        Precipitation Rain { get; set; }
        Precipitation Snow { get; set; }
    }
}
