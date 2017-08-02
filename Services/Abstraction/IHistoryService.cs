using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;
using Domain.Entities.Abstraction;

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
    }
}
