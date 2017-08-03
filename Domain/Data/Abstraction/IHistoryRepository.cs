using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;
using System.Threading.Tasks;

namespace Domain.Data.Abstraction
{
    public interface IHistoryRepository : IRepository<HistoryEntry>
    {
        IEnumerable<HistoryEntry> GetByCityId(int id);
        HistoryEntry GetById(Guid id);

        Task<IEnumerable<HistoryEntry>> GetByCityIdAsync(int id);
        Task<HistoryEntry> GetByIdAsync(Guid id);
    }
}
