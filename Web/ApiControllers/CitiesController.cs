using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Domain.Entities.Concretic;
using Domain.Exceptions;
using Services.Abstraction;
using Services.Exceptions;

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

        [Route("{cityId}")]
        [HttpGet]
        public HttpResponseMessage GetById(int cityId)
        {
                var result = _citiesService.GetSelected().FirstOrDefault(c => c.Id == cityId);
            if (result == null)
                return Request.CreateResponse(HttpStatusCode.OK, $"City with id: {cityId} not found in selected list.");
            return Request.CreateResponse(HttpStatusCode.OK, result);
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
            catch (CityNotFoundException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch (ItemAlreadyExistException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("{cityId}")]
        [HttpDelete]
        public HttpResponseMessage DeleteCity(int cityId)
        {
            try
            {
                _citiesService.RemoveFromSelected(_citiesService.GetCityById(cityId));
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            catch(ItemNotExistException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [Route("{cityId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request)
        {
            var data = await request.Content.ReadAsStringAsync();
            City city = JsonConvert.DeserializeObject<City>(data);
            try
            {
                _citiesService.UpdateInSelected(_citiesService.GetCityById(city.Id));
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (ItemNotExistException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        private readonly ICitiesService _citiesService;
    }
}
