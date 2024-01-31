using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferedAmenitiesController(IServiceOfAll<OfferedAmenitiesDTO> offeredAmenitiesService) : ControllerBase
    {
        // GET: api/offeredAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferedAmenitiesDTO>>> GetOfferedAmenities()
        {
            var offeredAmenities = await offeredAmenitiesService.GetAll();
            if (offeredAmenities == null || !offeredAmenities.Any())
            {
                return NotFound();
            }
            return Ok(offeredAmenities);
        }

        // GET: api/offeredAmenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferedAmenitiesDTO>> GetOfferedAmenities(int id)
        {
            var offeredAmenities = await offeredAmenitiesService.Get(id);
            if (offeredAmenities == null)
            {
                return NotFound();
            }
            return offeredAmenities;
        }

        // PUT: api/offeredAmenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfferedAmenities(int id, OfferedAmenitiesDTO offeredAmenities)
        {
            if (id != offeredAmenities.Id)
            {
                return BadRequest();
            }
            await offeredAmenitiesService.Update(offeredAmenities);
            return NoContent();
        }

        // POST: api/offeredAmenities
        [HttpPost]
        public async Task<ActionResult<OfferedAmenitiesDTO>> PostOfferedAmenities(OfferedAmenitiesDTO offeredAmenities)
        {
            await offeredAmenitiesService.Create(offeredAmenities);
            return CreatedAtAction(nameof(GetOfferedAmenities), new { id = offeredAmenities.Id }, offeredAmenities);
        }

        // DELETE: api/offeredAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfferedAmenities(int id)
        {
            await offeredAmenitiesService.Delete(id);
            return NoContent();
        }
    }
}
