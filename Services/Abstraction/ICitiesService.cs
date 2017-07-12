using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities.Location;

namespace Services.Abstraction
{
    public interface ICitiesService
    {
        City GetCityByName(string name);
    }
}
