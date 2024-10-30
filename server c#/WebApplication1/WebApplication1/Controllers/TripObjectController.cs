using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripObjectController : ControllerBase
    {

        private readonly ITripObjectService service;

        public TripObjectController(ITripObjectService service)
        {
            this.service = service;
        }

        // GET: api/<TripObjectController>
        [HttpGet]
        public Task<List<TripObjectDto>> Get()
        {
            return service.GetAll();
        }


        // GET api/<TripObjectController>/ById/5
        [HttpGet("ById/{id}")]
        public Task<TripObjectDto> GetById(int id)
        {
            return service.GetById(id);
        }

        // GET api/<TripObjectController>/ByAreaId/5
        [HttpGet("ByAreaId/{id}")]
        public Task<List<TripObjectDto>> GetByAreaId(int id)
        {
            return service.GetByAreaId(id);
        }


        // POST api/<TripObjectController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TripObjectDto item)
        {
            if (item == null)
            {
                return NotFound("trip object is null");
            }
            return Ok(await service.AddItem(item));

        }

        // PUT api/<TripObjectController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TripObjectDto item)
        {
            await service.UpdateItem(item, id);
        }

        // DELETE api/<TripObjectController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
