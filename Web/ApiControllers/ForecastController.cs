using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using Newtonsoft.Json;

using Services.Abstraction;
using Domain.Entities.Abstraction;

namespace Web.ApiControllers
{
    [RoutePrefix("api/forecast")]
    public class ForecastController : ApiController
    {
        public ForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetByCity([FromUri]string city, [FromUri]int days)
        {
            try
            {
                var result = _weatherService.LongForecast(city, days);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        private readonly IWeatherService _weatherService;
    }
}
