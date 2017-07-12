using System.Collections.Generic;

using Domain.Entities;

namespace Domain.Data.Abstraction
{
    public interface IQueriesRepository : IRepository<ForecastQueryInfo>
    {
        IEnumerable<ForecastQueryInfo> GetByCityId(int id);
    }
}
