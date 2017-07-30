using System;
using System.Web.Mvc;

using Services.Abstraction;

namespace Web.Controllers
{
    public class ForecastController : Controller
    {
        public ForecastController(IWeatherService weatherService, IHistoryService historyService)
        {
            _weatherService = weatherService;
            _historyService = historyService;
        }

        public ActionResult Hourly(string city)
        {
            try
            {
                var forecast = _weatherService.MediumForecast(city);
                _historyService.AddToHistory(forecast);
                return View(forecast);
            }
            catch(Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult Daily(string city)
        {
            try
            {
                var forecast = _weatherService.LongForecast(city);
                _historyService.AddToHistory(forecast);
                return View(forecast);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult Weather(string city)
        {
            try
            {
                var forecast = _weatherService.CurrentWeather(city);
                _historyService.AddToHistory(forecast);
                return View(forecast);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        private IWeatherService _weatherService;
        private IHistoryService _historyService;
    }
}