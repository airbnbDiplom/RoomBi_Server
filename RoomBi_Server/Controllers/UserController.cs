using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IServiceOfAll<UserDTO> userService) : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await userService.GetAll();
            if (users == null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await userService.Update(user);
            return NoContent();
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterUser(string email, string password)
        {
            var user = new UserDTO { Email = email, Password = password };
            await userService.Create(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(string email, string password)
        {
            var user = await userService.GetByEmailAndPassword(email, password);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.Delete(id);
            return NoContent();
        }
    }
}
