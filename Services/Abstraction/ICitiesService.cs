using System.Collections.Generic;

using Domain.Entities.Concretic;

namespace Services.Abstraction
{
    public interface ICitiesService
    {
        City GetCityByName(string name);
        City GetCityById(int id);
        List<City> GetSelected();
        void AddToSelected(City city);
        void RemoveFromSelected(City city);
    }
}
