using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IService<AreasDto> service;

        public AreasController(IService<AreasDto> service)
        {
            this.service = service;
        }

        // GET: api/<AreasController>
        [HttpGet]
        public Task<List<AreasDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<AreasController>/5
        [HttpGet("{id}")]
        public Task<AreasDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<AreasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AreasDto item)
        {
            if (item == null)
            {
                return NotFound("area is null");
            }
            return Ok(await service.AddItem(item));

        }

        // PUT api/<AreasController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AreasDto item)
        {
           await service.UpdateItem(item, id);
        }

        // DELETE api/<AreasController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await service.DeleteItem(id);
        }
    }
}
