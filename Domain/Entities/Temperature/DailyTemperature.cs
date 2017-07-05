namespace Domain.Entities.Temperature
{
    public class DailyTemperature : DefaultTemperature
    {
        public double? DayTemperature { get; set; }
        public double? MorningTemperature { get; set; }
        public double? EveningTemperature { get; set; }
    }
}
