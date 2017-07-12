using System;
using System.Web.Mvc;

using Services.Abstraction;
using Services;
using Domain.Data.Abstraction;

namespace Web.Controllers
{
    public class ForecastController : Controller
    {
        public ForecastController(IWeatherService weatherService, IQueriesRepository queries)
        {
            _weatherService = weatherService;
            _forecastQueriesLogger = new ForecastQueryLogger(queries);
        }

        public ActionResult Hourly(string city)
        {
            try
            {
                var forecast = _weatherService.MediumForecast(city);
                _forecastQueriesLogger.SaveQuery(forecast);
                return View(forecast);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Daily(string city)
        {
            try
            {
                var forecast = _weatherService.LongForecast(city);
                _forecastQueriesLogger.SaveQuery(forecast);
                return View(forecast);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Weather(string city)
        {
            try
            {
                var forecast = _weatherService.CurrentWeather(city);
                _forecastQueriesLogger.SaveQuery(forecast);
                return View(forecast);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private IWeatherService _weatherService;
        private ForecastQueryLogger _forecastQueriesLogger;
    }
}