using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;

namespace Domain.Data.Abstraction
{
    public interface IHistoryRepository : IRepository<HistoryEntry>
    {
        IEnumerable<HistoryEntry> GetByCityId(int id);
        HistoryEntry GetById(Guid id);
    }
}
