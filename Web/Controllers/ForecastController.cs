using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Services.Abstraction;
using Services.Concrete;

namespace Web.Controllers
{
    public class ForecastController : Controller
    {
        public IActionResult Hourly()
        {
            return View();
        }

        public IActionResult Daily()
        {
            return View();
        }

        public IActionResult Weather(string city)
        {
            IWeatherService weatherService = new OpenWeatherService(city);
            return View(weatherService.CurrentWeather);
        }
    }
}