using Newtonsoft.Json;

namespace Domain.Entities.Weather
{
    public class Wind
    {
        public double Speed { get; set; }
        public int Degrees { get; set; }

        public Wind(double speed, int deg)
        {
            Speed = speed;
            Degrees = deg;
        }
    }
}
