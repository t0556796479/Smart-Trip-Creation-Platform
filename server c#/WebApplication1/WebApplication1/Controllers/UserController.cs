using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyProject.Common.Entities;
using MyProject.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;

        private readonly ILoginService service;
        public UserController(ILoginService service, IConfiguration config)
        {

            this.service = service;
            this._configuration = config;
        }

        // GET: api/<UserController>
        [HttpGet]
        public Task<List<UserDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Task<UserDto> Get(int id)
        {
            return service.GetById(id);
        }

        [HttpPost("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var user = service.Login(username, password);
            if (user != null)
            {

                var token = Generate(user);
                var loginUser = new { token, user };
                return Ok(loginUser);
            }
            return BadRequest("User not found");

        }

        private string Generate(UserDto user)
        {
            //מפתח להצפנה
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //אלגוריתם להצפנה
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Surname,user.Name),
            new Claim(ClaimTypes.Role,user.Role),
            new Claim(ClaimTypes.GivenName,user.Name)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto item)
        {
            if (item == null)
            {
                return NotFound("user is null");
            }
            return Ok(await service.AddItem(item));

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDto item)
        {
            await service.UpdateItem(item, id);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
