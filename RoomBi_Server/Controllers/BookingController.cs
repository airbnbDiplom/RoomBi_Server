using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class BookingsController(IServiceOfAll<BookingDTO> bookingService) : ControllerBase
        {
            // GET: api/Bookings
            [HttpGet]
            public async Task<ActionResult<IEnumerable<BookingDTO>>> GetBookings()
            {
                var bookings = await bookingService.GetAll();
                if (bookings == null || !bookings.Any())
                {
                    return NotFound();
                }
                return Ok(bookings);
            }

            // GET: api/Bookings/5
            [HttpGet("{id}")]
            public async Task<ActionResult<BookingDTO>> GetBooking(int id)
            {
                var booking = await bookingService.Get(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return booking;
            }

            // PUT: api/Bookings/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutBooking(int id, BookingDTO booking)
            {
                if (id != booking.Id)
                {
                    return BadRequest();
                }
                await bookingService.Update(booking);
                return NoContent();
            }

            // POST: api/Bookings
            [HttpPost]
            public async Task<ActionResult<BookingDTO>> PostBooking(BookingDTO booking)
            {
                await bookingService.Create(booking);
                //return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
                return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
            }

            // DELETE: api/Bookings/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBanguage(int id)
            {
                await bookingService.Delete(id);
                return NoContent();
            }
        }
}
