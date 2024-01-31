using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsAboutGuestController(IServiceOfAll<CommentsAboutGuestDTO> commentsAboutGuestService) : ControllerBase
    {
        // GET: api/commentsAboutGuests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentsAboutGuestDTO>>> GetCommentsAboutGuests()
        {
            var commentsAboutGuests = await commentsAboutGuestService.GetAll();
            if (commentsAboutGuests == null || !commentsAboutGuests.Any())
            {
                return NotFound();
            }
            return Ok(commentsAboutGuests);
        }

        // GET: api/commentsAboutGuests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentsAboutGuestDTO>> GetCommentsAboutGuest(int id)
        {
            var commentsAboutGuest = await commentsAboutGuestService.Get(id);
            if (commentsAboutGuest == null)
            {
                return NotFound();
            }
            return commentsAboutGuest;
        }

        // PUT: api/commentsAboutGuests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentsAboutGuest(int id, CommentsAboutGuestDTO commentsAboutGuest)
        {
            if (id != commentsAboutGuest.Id)
            {
                return BadRequest();
            }
            await commentsAboutGuestService.Update(commentsAboutGuest);
            return NoContent();
        }

        // POST: api/commentsAboutGuests
        [HttpPost]
        public async Task<ActionResult<CommentsAboutGuestDTO>> PostCommentsAboutGuest(CommentsAboutGuestDTO commentsAboutGuest)
        {
            await commentsAboutGuestService.Create(commentsAboutGuest);
            return CreatedAtAction(nameof(GetCommentsAboutGuest), new { id = commentsAboutGuest.Id }, commentsAboutGuest);
        }

        // DELETE: api/commentsAboutGuests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentsAboutGuest(int id)
        {
            await commentsAboutGuestService.Delete(id);
            return NoContent();
        }
    }
}
