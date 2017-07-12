using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Abstraction;

namespace Domain.Entities.Location
{
    public class SelectedCity : City
    {
        public SelectedCity() { }

        public SelectedCity(City city)
        {
            Id = city.Id;
            Name = city.Name;
            Country = city.Country;
            Coordinates = city.Coordinates;
        }
    }
}
