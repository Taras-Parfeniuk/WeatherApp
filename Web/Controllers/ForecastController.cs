using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using Services.Abstraction;
using Services.Concrete;

namespace Web.Controllers
{
    public class ForecastController : Controller
    {
        public ForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public ActionResult Hourly(string city)
        {
            try
            {
                return View(_weatherService.MediumForecast);
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
                return View(_weatherService.LongForecast);
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
                return View(_weatherService.CurrentWeather);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private IWeatherService _weatherService;
    }
}