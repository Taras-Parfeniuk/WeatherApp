using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstraction
{
    public interface IDayForecast : IBaseForecast
    {
        double? MorningTemperature { get; set; }
        double? DayTemperature { get; set; }
        double? EveningTemperature { get; set; }
    }
}
