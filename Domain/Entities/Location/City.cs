using Domain.Entities.Abstraction;
using System.Collections.Generic;

namespace Domain.Entities.Location
{
    public class City : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Coordinates Coordinates { get; set; }

        public City() { }
    }
}
