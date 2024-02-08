using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestСommentsController(IServiceOfAll<GuestCommentsForRentalItemDTO> guestCommentsService) : ControllerBase
    {
   

        // GET: api/guestСomments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestCommentsForRentalItemDTO>>> GetGuestComments()
        {
            var guestСomments = await guestCommentsService.GetAll() ;

            if (guestСomments == null || !guestСomments.Any())
            {
                return NotFound();
            }
            return Ok(guestСomments);
        }

        // GET: api/guestСomments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestCommentsForRentalItemDTO>> GetGuestComments(int id)
        {
            var guestСomments = await guestCommentsService.Get(id);
            if (guestСomments == null)
            {
                return NotFound();
            }
            return guestСomments;
        }

        // PUT: api/guestСomments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestСomments(int id, GuestCommentsForRentalItemDTO guestСomments)
        {
            if (id != guestСomments.Id)
            {
                return BadRequest();
            }
            await guestCommentsService.Update(guestСomments);
            return NoContent();
        }

        // POST: api/guestСomments
        [HttpPost]
        public async Task<ActionResult<GuestCommentsForRentalItemDTO>> PostGuestСomments(GuestCommentsForRentalItemDTO guestСomments)
        {
            await guestCommentsService.Create(guestСomments);
            //return CreatedAtAction("GetGuestСomments", new { id = guestСomments.Id }, guestСomments);
            return CreatedAtAction(nameof(GetGuestComments), new { id = guestСomments.Id }, guestСomments);
        }

        // DELETE: api/guestСomments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestСomments(int id)
        {
            await guestCommentsService.Delete(id);
            return NoContent();
        }
    }
}
