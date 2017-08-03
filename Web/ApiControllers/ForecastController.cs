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
using System.Threading.Tasks;

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
        public async Task<HttpResponseMessage> GetDailyByCity([FromUri]string city, [FromUri]int days)
        {
            try
            {
                var result = await _weatherService.LongForecastAsync(city, days);
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
        public async Task<HttpResponseMessage> GetHourlyByCity([FromUri]string city)
        {
            try
            {
                var result = await _weatherService.MediumForecastAsync(city);
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
        public async Task<HttpResponseMessage> GetHourlyByCity([FromUri]string city, [FromUri]bool sorted)
        {
            try
            {
                var forecast = await _weatherService.MediumForecastAsync(city);
                var result = new SortedMultipleForecast(forecast);

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
        public async Task<HttpResponseMessage> GetCurrentByCity([FromUri]string city)
        {
            try
            {
                var result =await  _weatherService.CurrentWeatherAsync(city);
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
