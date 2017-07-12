using System.Collections.Generic;

using Domain.Data.Abstraction;
using Domain.Entities.Abstraction;
using Domain.Entities;

namespace Services
{
    public class ForecastQueryLogger
    {
        public ForecastQueryLogger(IQueriesRepository queriesRepo)
        {
            _queriesRepository = queriesRepo;
        }

        public void SaveQuery(IMediumForecast forecast)
        {
            _queriesRepository.Add(new ForecastQueryInfo(forecast));
        }

        public void SaveQuery(ILongForecast forecast)
        {
            _queriesRepository.Add(new ForecastQueryInfo(forecast));
        }

        public void SaveQuery(ICurrentWeather forecast)
        {
            _queriesRepository.AddOrUpdate(new ForecastQueryInfo(forecast));
        }

        public IEnumerable<ForecastQueryInfo> GetAllQueries()
        {
            return _queriesRepository.GetAll();
        }

        private IQueriesRepository _queriesRepository;
    }
}
