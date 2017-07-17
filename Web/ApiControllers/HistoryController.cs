using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Services.Abstraction;
using System.Threading.Tasks;

namespace Web.ApiControllers
{
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

        private readonly IHistoryService _historyService;
    }
}
