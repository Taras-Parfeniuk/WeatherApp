using Newtonsoft.Json;

namespace Domain.Entities.Weather
{
    public class Measurements
    {
        public int? DefaultPressure { get; set; }
        public int? GroundLevelPressure { get; set; }
        public int? SeaLevelPressure { get; set; }
        public int? Humidity { get; set; }
    }
}
