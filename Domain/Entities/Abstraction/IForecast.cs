using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Weather;

namespace Domain.Entities.Abstraction
{
    public interface IForecast
    {
        WeatherState Weather { get; set; }
        double? MinTemperature { get; set; }
        double? MaxTemperature { get; set; }
        double? MorningTemperature { get; set; }
        double? DayTemperature { get; set; }
        double? EveningTemperature { get; set; }
        double? CurrentTemperature { get; set; }
        Measurements MainMeathurements { get; set; }
        Wind Wind { get; set; }
        double? Cloudiness { get; set; }
        DateTime MeathurementsTime { get; set; }
        DateTime ForecastTime { get; set; }

        Precipitation Rain { get; set; }
        Precipitation Snow { get; set; }
    }
}
