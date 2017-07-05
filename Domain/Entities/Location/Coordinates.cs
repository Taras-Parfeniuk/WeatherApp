using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Location
{
    public class Coordinates
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Coordinates(double lon, double lat)
        {
            Longitude = lon;
            Latitude = lat;
        }
    }
}
