using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstraction
{
    public interface IBaseForecast
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
    }
}
