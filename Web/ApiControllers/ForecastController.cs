using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Cors;

using Newtonsoft.Json;

using Services.Abstraction;
using Domain.Entities.Abstraction;
using Domain.Entities.Concretic;

namespace Web.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/forecast")]
    public class ForecastController : ApiController
    {
        public ForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("daily")]
        [HttpGet]
        public HttpResponseMessage GetDailyByCity([FromUri]string city, [FromUri]int days)
        {
            try
            {
                var result = _weatherService.LongForecast(city, days);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("hourly")]
        [HttpGet]
        public HttpResponseMessage GetHourlyByCity([FromUri]string city)
        {
            try
            {
                var result = _weatherService.MediumForecast(city);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("hourly")]
        [HttpGet]
        public HttpResponseMessage GetHourlyByCity([FromUri]string city, [FromUri]bool sorted)
        {
            try
            {
                var result = new SortedMultipleForecast(_weatherService.MediumForecast(city));

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("current")]
        [HttpGet]
        public HttpResponseMessage GetCurrentByCity([FromUri]string city)
        {
            try
            {
                var result = _weatherService.CurrentWeather(city);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        private readonly IWeatherService _weatherService;
    }
}
