using System.Collections.Generic;

using Domain.Entities;

namespace Domain.Data.Abstraction
{
    public interface IQueriesRepository : IRepository<ForecastQueryInfo>
    {
        IEnumerable<ForecastQueryInfo> GetByCityName(string name);
        IEnumerable<ForecastQueryInfo> GetByCityId(int id);
    }
}
