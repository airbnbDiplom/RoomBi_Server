using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using System.Diagnostics;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalApartmentController(IServiceOfAll<RentalApartmentDTO> rentalApartmentService, 
        IServiceForStartPage<RentalApartmentDTOForStartPage> serviceForStartPage,
        IServiceForMap<RentalApartmentForMap> serviceForMap) : ControllerBase
    {
     

        // GET: api/rentalApartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetRentalApartments(int page = 1, int pageSize = 24)
        {
            if (page == 2)
            {
                var rentalApartments = await serviceForStartPage.GetAllForStartPage(page, pageSize);
                if (rentalApartments == null || !rentalApartments.Any())
                {
                    return NotFound();
                }
                return Ok(rentalApartments);
            }
            else 
            {
              var rentalApartments = await serviceForStartPage.GetAllForStartPage(page, pageSize);
                if (rentalApartments == null || !rentalApartments.Any())
                {
                    return NotFound();
                }
                return Ok(rentalApartments);
            }
            

        }
        // GET: api/rentalApartments/map
        [HttpGet("map/{map}")]
        public async Task<ActionResult<IEnumerable<RentalApartmentForMap>>> GetRentalApartments(string map)
        {
            var rentalApartments = await serviceForMap.GetAllForMap(map);
            if (rentalApartments == null || !rentalApartments.Any())
            {
                return NotFound();
            }
            return Ok(rentalApartments);
        }

        // GET: api/rentalApartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalApartmentDTO>> GetRentalApartment(int id)
        {
            var rentalApartment = await rentalApartmentService.Get(id);
            if (rentalApartment == null)
            {
                return NotFound();
            }
            return rentalApartment;
        }
        // POST: api/rentalApartments/{id}
        [HttpPost("card/{id}")]
        public async Task<ActionResult<RentalApartmentDTOForStartPage>> CardRentalApartment(int id)
        {
            var rentalApartment = await serviceForStartPage.GetCard(id);
            if (rentalApartment == null)
            {
                return NotFound();
            }
            return rentalApartment;
        }

        // PUT: api/rentalApartments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalApartment(int id, RentalApartmentDTO rentalApartment)
        {
            if (id != rentalApartment.Id)
            {
                return BadRequest();
            }
            await rentalApartmentService.Update(rentalApartment);
            return NoContent();
        }

        // POST: api/rentalApartments
        [HttpPost]
        public async Task<ActionResult<RentalApartmentDTO>> PostRentalApartment(RentalApartmentDTO rentalApartment)
        {
            await rentalApartmentService.Create(rentalApartment);
            return CreatedAtAction(nameof(GetRentalApartment), new { id = rentalApartment.Id }, rentalApartment);
        }

        // DELETE: api/rentalApartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalApartment(int id)
        {
            await rentalApartmentService.Delete(id);
            return NoContent();
        }
    }
}
