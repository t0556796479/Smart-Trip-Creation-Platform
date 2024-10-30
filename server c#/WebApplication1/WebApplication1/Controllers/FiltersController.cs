using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;
using MyProject.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IFiltersService service;

        public FiltersController(IFiltersService service)
        {
            this.service = service;
        }

        // GET: api/<FiltersController>
        [HttpGet]
        public Task<List<FiltersDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<FiltersController>/5
        [HttpGet("{id}")]
        public Task<FiltersDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<FiltersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FiltersDto item)
        {
            if (item == null)
            {
                return NotFound("filter is null");
            }
            return Ok(await service.AddItem(item));

        }

        // PUT api/<FiltersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FiltersDto item)
        {
            await service.UpdateItem(item, id);
        }

        // DELETE api/<FiltersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
