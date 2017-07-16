using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

using Newtonsoft.Json;

using Domain.Entities.Concretic;
using Services.Abstraction;
using System.Threading.Tasks;

namespace Web.ApiControllers
{
    [RoutePrefix("api/cities")]
    public class CitiesController : ApiController
    {
        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var result = _citiesService.GetSelected();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostCity(HttpRequestMessage request)
        {
            var data = await request.Content.ReadAsStringAsync();
            City city = JsonConvert.DeserializeObject<City>(data);

            try
            {
                _citiesService.AddToSelected(_citiesService.GetCityById(city.Id));
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [Route("{cityId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteCity(HttpRequestMessage request)
        {
            var data = await request.Content.ReadAsStringAsync();
            City city = JsonConvert.DeserializeObject<City>(data);
            try
            {
                _citiesService.RemoveFromSelected(_citiesService.GetCityById(city.Id));
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        private readonly ICitiesService _citiesService;
    }
}
