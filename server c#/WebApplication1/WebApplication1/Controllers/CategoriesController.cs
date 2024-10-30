using Microsoft.AspNetCore.Mvc;
using MyProject.Common.Entities;
using MyProject.Repository.Entities;
using MyProject.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IService<CategoriesDto> service;

        public CategoriesController(IService<CategoriesDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public Task<List<CategoriesDto>> Get()
        {
           return service.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Task<CategoriesDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriesDto item)
        {
            if (item == null)
            {
                return NotFound("category is null");
            }
            return Ok(await service.AddItem(item));

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CategoriesDto item)
        {
            await service.UpdateItem(item, id);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await service.DeleteItem(id);
        }
    }
}
