using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Domain.Entities.Concretic;
using Services.Abstraction;

namespace Web.Controllers
{
    public class HistoryController : Controller
    {
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET: History
        public ActionResult Queries(string cityName)
        {
            List<ForecastQueryInfo> queries = 
                cityName != string.Empty && cityName != null
                ? queries = _historyService.GetHistoryByCity(cityName).ToList() 
                : _historyService.GetHistory();
            return View(queries);
        }

        public ActionResult Forecasts(Guid queryId)
        {
            return View(_historyService.GetEntryById(queryId));
        }

        private IHistoryService _historyService;
    }
}