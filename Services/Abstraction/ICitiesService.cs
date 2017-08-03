using System.Collections.Generic;

using Domain.Entities.Concretic;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface ICitiesService
    {
        City GetCityByName(string name);
        City GetCityById(int id);
        List<City> GetSelected();
        List<City> GetDefault();
        void UpdateInSelected(City city);
        void AddToSelected(City city);
        void RemoveFromSelected(City city);

        Task<City> GetCityByNameAsync(string name);
        Task<City> GetCityByIdAsync(int id);
        Task<List<City>> GetSelectedAsync();
        Task<List<City>> GetDefaultAsync();
        Task UpdateInSelectedAsync(City city);
        Task AddToSelectedAsync(City city);
        Task RemoveFromSelectedAsync(City city);
    }
}
