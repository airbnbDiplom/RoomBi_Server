using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi_Server.Token;
using System.Security.Claims;

namespace RoomBi_Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IServiceBooking<BookingDTO> bookingService,
        IJwtToken jwtTokenService, IServiceGetAllIdUser<BookingDTOWithFoto> serviceGetAllIdUser) : ControllerBase
    {
        [Authorize]
        // POST: api/Bookings
        [HttpPost]
        public async Task<IActionResult> PostBooking(BookingDTO bookingDto)
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            bookingDto.OwnerId = int.Parse(jwtTokenService.GetIdFromToken(principal));
            await bookingService.CreateBooking(bookingDto);
            return Ok(bookingDto);
        }


        [Authorize]
        //GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTOWithFoto>>> GetBookings()
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
            //int temp = 1;
            var bookings = await serviceGetAllIdUser.GetAllObj(temp);
            if (bookings == null || !bookings.Any())
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // GET: api/Bookings/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DateBooking>> GetBooking(int id)
        //{
        //    var booking = await bookingService.Get(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }
        //    return booking;
        //}

        // PUT: api/Bookings/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBooking(int id, DateBooking booking)
        //{
        //    if (id != booking.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await bookingService.Update(booking);
        //    return NoContent();
        //}


        // DELETE: api/Bookings/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBanguage(int id)
        //{
        //    await bookingService.Delete(id);
        //    return NoContent();
        //}
    }
}
