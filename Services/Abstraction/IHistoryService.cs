using System;
using System.Collections.Generic;

using Domain.Entities.Concretic;
using Domain.Entities.Abstraction;

namespace Services.Abstraction
{
    public interface IHistoryService
    {
        void AddToHistory(ILongForecast forecast);
        void AddToHistory(IMediumForecast forecast);
        void AddToHistory(ICurrentWeather forecast);
        List<ForecastQueryInfo> GetHistory();
        List<ForecastQueryInfo> GetHistoryByCity(string cityName);
        List<ForecastQueryInfo> GetHistoryByCity(City city);
        ForecastQueryInfo GetEntryById(Guid id);
    }
}
