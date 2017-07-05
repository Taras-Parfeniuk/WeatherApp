using System;
using System.Collections.Generic;
using System.Text;

using Domain.Entities.Location;

namespace Domain.Data
{
    public interface ICityRepository
    {
        IEnumerable<City> Cities { get; }
    }
}
