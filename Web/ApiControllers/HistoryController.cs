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
        public async Task<HttpResponseMessage> GetHistory()
        {
            var result = await _historyService.GetHistoryAsync();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("{queryId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetEntryById(Guid queryId)
        {
            var result = await _historyService.GetEntryByIdAsync(queryId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetHistoryByCity([FromUri]string cityName)
        {
            var result = await _historyService.GetHistoryByCityAsync(cityName);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        private readonly IHistoryService _historyService;
    }
}
