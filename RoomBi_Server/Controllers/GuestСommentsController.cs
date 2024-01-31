using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestСommentsController(IServiceOfAll<GuestСommentsDTO> guestСommentsService) : ControllerBase
    {
        // GET: api/guestСomments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestСommentsDTO>>> GetGuestСomments()
        {
            var guestСomments = await guestСommentsService.GetAll();
            if (guestСomments == null || !guestСomments.Any())
            {
                return NotFound();
            }
            return Ok(guestСomments);
        }

        // GET: api/guestСomments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestСommentsDTO>> GetGuestСomments(int id)
        {
            var guestСomments = await guestСommentsService.Get(id);
            if (guestСomments == null)
            {
                return NotFound();
            }
            return guestСomments;
        }

        // PUT: api/guestСomments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestСomments(int id, GuestСommentsDTO guestСomments)
        {
            if (id != guestСomments.Id)
            {
                return BadRequest();
            }
            await guestСommentsService.Update(guestСomments);
            return NoContent();
        }

        // POST: api/guestСomments
        [HttpPost]
        public async Task<ActionResult<GuestСommentsDTO>> PostGuestСomments(GuestСommentsDTO guestСomments)
        {
            await guestСommentsService.Create(guestСomments);
            //return CreatedAtAction("GetGuestСomments", new { id = guestСomments.Id }, guestСomments);
            return CreatedAtAction(nameof(GetGuestСomments), new { id = guestСomments.Id }, guestСomments);
        }

        // DELETE: api/guestСomments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestСomments(int id)
        {
            await guestСommentsService.Delete(id);
            return NoContent();
        }
    }
}
