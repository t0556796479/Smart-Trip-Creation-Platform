using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertiesService service;

        public PropertiesController(IPropertiesService service)
        {
            this.service = service;
        }

        // GET: api/<PropertiesController>
        [HttpGet]
        public Task<List<PropertiesDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public Task<PropertiesDto> Get(int id)
        {
            return service.GetById(id);
        }


        // POST api/<PropertiesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PropertiesDto item)
        {
            if (item == null)
            {
                return NotFound("property is null");
            }
            return Ok(await service.AddItem(item));

        }


        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PropertiesDto item)
        {
            await service.UpdateItem(item, id);
        }

        // DELETE api/<PropertiesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
