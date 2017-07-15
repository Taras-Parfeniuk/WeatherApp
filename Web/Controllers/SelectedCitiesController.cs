using System;
using System.Web.Mvc;

using Services.Abstraction;


namespace Web.Controllers
{
    public class SelectedCitiesController : Controller
    {
        public SelectedCitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        // GET: SelectedCities
        [HttpGet]
        public ActionResult Index()
        {
            return View(_citiesService.GetSelected());
        }

        [HttpPost]
        public ActionResult Add(string cityName)
        {
            try
            {
                _citiesService.AddToSelected(_citiesService.GetCityByName(cityName));
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
                _citiesService.RemoveFromSelected(_citiesService.GetCityById(cityId));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        private ICitiesService _citiesService;
    }
}