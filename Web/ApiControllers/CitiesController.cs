using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;
using System.Web.Http.Cors;

using Newtonsoft.Json;

using Domain.Entities.Concretic;
using Domain.Exceptions;
using Services.Abstraction;
using Services.Exceptions;

namespace Web.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/cities")]
    public class CitiesController : ApiController
    {
        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            var result = await _citiesService.GetSelectedAsync();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("default")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetDefault()
        {
            var result = await _citiesService.GetDefaultAsync();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetByName([FromUri]string cityName)
        {
            var result = await _citiesService.GetCityByNameAsync(cityName);

            if (result == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, $"City with name: {cityName} not found.");
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("{cityId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(int cityId)
        {
            var cities = await _citiesService.GetSelectedAsync();
            var result = cities.FirstOrDefault(c => c.Id == cityId);

            if (result == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, $"City with id: {cityId} not found in selected list.");
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
                await _citiesService.AddToSelectedAsync(_citiesService.GetCityById(city.Id));
                return Request.CreateResponse(HttpStatusCode.Created, city);
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
        public async Task<HttpResponseMessage> DeleteCity(int cityId)
        {
            try
            {
                await _citiesService.RemoveFromSelectedAsync(_citiesService.GetCityById(cityId));
                return Request.CreateResponse(HttpStatusCode.NoContent);
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
                city = await _citiesService.GetCityByIdAsync(city.Id);
                await _citiesService.UpdateInSelectedAsync(city);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ItemNotExistException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        private readonly ICitiesService _citiesService;
    }
}
