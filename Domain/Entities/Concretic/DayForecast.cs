using Domain.Entities.Abstraction;

namespace Domain.Entities.Concretic
{
    public class DayForecast : BaseForecast, IDayForecast
    {
        public double? MorningTemperature { get; set; }
        public double? DayTemperature { get; set; }
        public double? EveningTemperature { get; set; }
    }
}
