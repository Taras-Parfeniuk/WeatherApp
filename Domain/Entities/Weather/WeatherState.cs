using Newtonsoft.Json;

namespace Domain.Entities.Weather
{
    public class WeatherState
    {
        public int? Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        public bool Equals(WeatherState obj)
        {
            bool isEqual;

            isEqual = Id == obj.Id;
            if (!isEqual)
                return isEqual;

            isEqual = Main == obj.Main;
            if (!isEqual)
                return isEqual;

            isEqual = Icon == obj.Icon;
            if (!isEqual)
                return isEqual;

            isEqual = Description == obj.Description;

            return isEqual;
        }
    }
}
