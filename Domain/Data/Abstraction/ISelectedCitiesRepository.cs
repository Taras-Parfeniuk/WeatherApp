using Domain.Entities.Concretic;
using System.Threading.Tasks;

namespace Domain.Data.Abstraction
{
    public interface ISelectedCitiesRepository : IRepository<City>
    {
        void Remove(int id);

        Task RemoveAsync(int id);
    }
}
