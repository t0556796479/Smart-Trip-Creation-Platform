using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithemController : ControllerBase
    {
        private readonly IAlgorithemService service;

          
        public AlgorithemController(IAlgorithemService service)
        {
            this.service = service;
        }


        [HttpPost]
        public Task<List<TripObjectDto>> Get([FromBody] AlgorithemRequestDto request)
        {
            return service.GetRoute(request);
        }

        [HttpGet("{categoryId}")]
        public Task<List<PropertyFilterDto>> Get(int categoryId)
        {
            return service.GetPropertiesByCategoryId(categoryId);
        }

        //// GET: api/<AlgorithemController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AlgorithemController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<AlgorithemController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AlgorithemController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AlgorithemController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
