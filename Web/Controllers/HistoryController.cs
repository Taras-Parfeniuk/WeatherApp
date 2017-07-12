using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Domain.Data.Abstraction;
using Domain.Entities;

namespace Web.Controllers
{
    public class HistoryController : Controller
    {
        public HistoryController(IQueriesRepository queries)
        {
            _queries = queries;
        }

        // GET: History
        public ActionResult Queries(string cityName)
        {
            List<ForecastQueryInfo> queries = 
                cityName != string.Empty && cityName != null
                ? queries = _queries.GetByCityName(cityName).ToList() 
                : _queries.GetAll();
            return View(queries);
        }

        public ActionResult Forecasts(Guid queryId)
        {
            return View(_queries.GetAll().Where(q => q.Id == queryId).FirstOrDefault());
        }

        private IQueriesRepository _queries;
    }
}