using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Services.Abstraction;
using Domain.Data.Abstraction;
using Domain.Entities.Location;

namespace Web.Controllers
{
    public class SelectedCitiesController : Controller
    {
        public SelectedCitiesController(ICitiesService citiesService, ISelectedCitiesRepository selectedCities)
        {
            _citiesService = citiesService;
            _selectedCities = selectedCities;
        }

        // GET: SelectedCities
        [HttpGet]
        public ActionResult Index()
        {
            return View(_selectedCities.GetAll());
        }

        [HttpPost]
        public ActionResult Add(string cityName)
        {
            try
            {
                var city = new SelectedCity(_citiesService.GetCityByName(cityName));
                _selectedCities.Add(city);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int cityId)
        {
            try
            {
                _selectedCities.Remove(cityId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private ICitiesService _citiesService;
        ISelectedCitiesRepository _selectedCities;
    }
}