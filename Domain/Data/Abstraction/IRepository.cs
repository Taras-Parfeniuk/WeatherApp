using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void AddOrUpdate(TEntity entity);

        List<TEntity> GetAll();

        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task AddOrUpdateAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync();
    }
}
