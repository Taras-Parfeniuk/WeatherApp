using Newtonsoft.Json;

namespace Domain.Entities.Weather
{
    public class WeatherState
    {
        public int? Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
