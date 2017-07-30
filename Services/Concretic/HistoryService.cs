using System;
using System.Linq;
using System.Collections.Generic;

using Ninject;

using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;
using Domain.Data.Abstraction;
using Services.Abstraction;
using Services.Util;

namespace Services.Concretic
{
    public class HistoryService : IHistoryService
    {
        public HistoryService(ICitiesService citiesService, IHistoryRepository historyRepository)
        {
            _citiesService = citiesService;
            _historyRepository = historyRepository;
        }

        public Guid AddToHistory(IMultipleForecast forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<StoredForecast>(forecast.SingleForecasts.Select(f => new StoredForecast(f))),
                Time = DateTime.Now
            };

            _historyRepository.AddOrUpdate(entry);
            return entry.Id;
        }

        public Guid AddToHistory(ICurrentWeather forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<StoredForecast>() { new StoredForecast(forecast) },
                Time = DateTime.Now
            };
            _historyRepository.AddOrUpdate(entry);
            return entry.Id;
        }

        public List<ForecastQueryInfo> GetHistory()
        {
            return _historyRepository.GetAll().Select(e => EntryToForecastQueryInfo(e)).ToList();
        }

        public List<ForecastQueryInfo> GetHistoryByCity(City city)
        {
            return _historyRepository.GetByCityId(city.Id).Select(e => EntryToForecastQueryInfo(e)).ToList();
        }

        public List<ForecastQueryInfo> GetHistoryByCity(string cityName)
        {
            return GetHistoryByCity(_citiesService.GetCityByName(cityName));
        }

        private ForecastQueryInfo EntryToForecastQueryInfo(HistoryEntry entry)
        {
            ForecastQueryInfo info = new ForecastQueryInfo()
            {
                Id = entry.Id,
                City = _citiesService.GetCityById(entry.CityId),
                Forecasts = entry.Forecasts,
                QueryTime = entry.Time
            };
            return info;
        }

        public ForecastQueryInfo GetEntryById(Guid id)
        {
            return EntryToForecastQueryInfo(_historyRepository.GetById(id));
        }

        private IKernel _kernel;
        private ICitiesService _citiesService;
        private IHistoryRepository _historyRepository;
    }
}
