using System;

namespace Domain.Entities.Abstraction
{
    public interface ISingleForecast
    {
        string WeatherIcon { get; set; }
        string WeatherState { get; set; }
        string WeatherDescription { get; set; }
        double? MinTemperature { get; set; }
        double? MaxTemperature { get; set; }
        int? DefaultPressure { get; set; }
        int? Humidity { get; set; }
        double? WindSpeed { get; set; }
        double? Cloudiness { get; set; }
        DateTime ForecastTime { get; set; }
        double? MorningTemperature { get; set; }
        double? DayTemperature { get; set; }
        double? EveningTemperature { get; set; }
        double? CurrentTemperature { get; set; }
        DateTime Sunrise { get; set; }
        DateTime Sunset { get; set; }
    }
}
