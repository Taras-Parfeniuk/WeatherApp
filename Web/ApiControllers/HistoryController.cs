using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Cors;

using Services.Abstraction;

namespace Web.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/history")]
    public class HistoryController : ApiController
    {
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetHistory()
        {
            var result = _historyService.GetHistory();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("{queryId}")]
        [HttpGet]
        public HttpResponseMessage GetHistoryByCity(Guid queryId)
        {
            var result = _historyService.GetEntryById(queryId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetHistoryByCity([FromUri]string cityName)
        {
            var result = _historyService.GetHistoryByCity(cityName);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        private readonly IHistoryService _historyService;
    }
}
