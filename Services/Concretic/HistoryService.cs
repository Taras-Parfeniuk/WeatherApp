using System;
using System.Linq;
using System.Collections.Generic;

using Ninject;

using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;
using Domain.Data.Abstraction;
using Services.Abstraction;
using Services.Util;
using System.Threading.Tasks;

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
                QueryTime = entry.Time
            };
            return info;
        }

        public QueryForecast GetEntryById(Guid id)
        {
            var entry = _historyRepository.GetById(id);

            var forecast = new QueryForecast()
            {
                City = _citiesService.GetCityById(entry.CityId),
                QueryTime = entry.Time,
                Forecasts = entry.Forecasts
            };

            return forecast;
        }

        public async Task<Guid> AddToHistoryAsync(IMultipleForecast forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<StoredForecast>(forecast.SingleForecasts.Select(f => new StoredForecast(f))),
                Time = DateTime.Now
            };

            await _historyRepository.AddOrUpdateAsync(entry);
            return entry.Id;
        }

        public async Task<Guid> AddToHistoryAsync(ICurrentWeather forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<StoredForecast>() { new StoredForecast(forecast) },
                Time = DateTime.Now
            };
            await _historyRepository.AddOrUpdateAsync(entry);
            return entry.Id;
        }

        public async Task<List<ForecastQueryInfo>> GetHistoryAsync()
        {
            var entries = await _historyRepository.GetAllAsync();

            return entries.Select(e => EntryToForecastQueryInfo(e)).ToList();
        }

        public async Task<List<ForecastQueryInfo>> GetHistoryByCityAsync(string cityName)
        {
            var city = await _citiesService.GetCityByNameAsync(cityName);

            return await GetHistoryByCityAsync(city);
        }

        public async Task<List<ForecastQueryInfo>> GetHistoryByCityAsync(City city)
        {
            var entries = await _historyRepository.GetByCityIdAsync(city.Id);

            return entries.Select(e => EntryToForecastQueryInfo(e)).ToList();
        }

        public async Task<QueryForecast> GetEntryByIdAsync(Guid id)
        {
            var entry = await _historyRepository.GetByIdAsync(id);
            var city = await _citiesService.GetCityByIdAsync(entry.CityId);
            return new QueryForecast()
            {
                City = city,
                QueryTime = entry.Time,
                Forecasts = entry.Forecasts
            };
        }

        private ICitiesService _citiesService;
        private IHistoryRepository _historyRepository;
    }
}
