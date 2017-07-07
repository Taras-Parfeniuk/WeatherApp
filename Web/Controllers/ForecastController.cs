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
        public ActionResult Hourly(string city)
        {
            IWeatherService weatherService = new OpenWeatherService(city);
            try
            {
                return View(weatherService.MediumForecast);
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Daily(string city)
        {
            IWeatherService weatherService = new OpenWeatherService(city);
            try
            { 
                return View(weatherService.LongForecast);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Weather(string city)
        {
            IWeatherService weatherService = new OpenWeatherService(city);
            try
            { 
                return View(weatherService.CurrentWeather);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}