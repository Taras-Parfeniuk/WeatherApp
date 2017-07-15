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
        public HistoryService()
        {
            _kernel = new StandardKernel(new ServicesNinjectModule());
            _citiesService = _kernel.Get<ICitiesService>();
            _historyRepository = _kernel.Get<IHistoryRepository>();
        }

        public Guid AddToHistory(IMediumForecast forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<Forecast>(forecast.HourForecasts.Select(f => new Forecast(f))),
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
                Forecasts = new List<Forecast>() { new Forecast(forecast) },
                Time = DateTime.Now
            };
            _historyRepository.AddOrUpdate(entry);
            return entry.Id;
        }

        public Guid AddToHistory(ILongForecast forecast)
        {
            HistoryEntry entry = new HistoryEntry()
            {
                Id = Guid.NewGuid(),
                CityId = forecast.City.Id,
                Forecasts = new List<Forecast>(forecast.DayForecasts.Select(f => new Forecast(f))),
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
