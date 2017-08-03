using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;
using Domain.Entities.Abstraction;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IHistoryService
    {
        Guid AddToHistory(IMultipleForecast forecast);
        Guid AddToHistory(ICurrentWeather forecast);
        List<ForecastQueryInfo> GetHistory();
        List<ForecastQueryInfo> GetHistoryByCity(string cityName);
        List<ForecastQueryInfo> GetHistoryByCity(City city);
        QueryForecast GetEntryById(Guid id);

        Task<Guid> AddToHistoryAsync(IMultipleForecast forecast);
        Task<Guid> AddToHistoryAsync(ICurrentWeather forecast);
        Task<List<ForecastQueryInfo>> GetHistoryAsync();
        Task<List<ForecastQueryInfo>> GetHistoryByCityAsync(string cityName);
        Task<List<ForecastQueryInfo>> GetHistoryByCityAsync(City city);
        Task<QueryForecast> GetEntryByIdAsync(Guid id);
    }
}
