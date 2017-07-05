using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Location
{
    public class City : ILocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
