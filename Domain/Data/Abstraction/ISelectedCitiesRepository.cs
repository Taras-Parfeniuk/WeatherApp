using Domain.Entities.Concretic;

namespace Domain.Data.Abstraction
{
    public interface ISelectedCitiesRepository : IRepository<City>
    {
        void Remove(int id);
    }
}
