using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestPaymentMethodController(IServiceOfAll<UserDTO> userService, IServiceOfAll<Payment> guestPaymentMethodService) : ControllerBase
    {
        // GET: api/guestPaymentMethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetguestPaymentMethods()
        {
            var guestPaymentMethods = await guestPaymentMethodService.GetAll();
            var token = HttpContext.Request.Headers.Authorization;
            //iGetIdFromToken(string token)
            if (guestPaymentMethods == null || !guestPaymentMethods.Any())
            {
                return NotFound();
            }
            return Ok(guestPaymentMethods);
        }

        // GET: api/guestPaymentMethods/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GuestPaymentMethodDTO>> GetGuestPaymentMethod(int id)
        //{
        //    var guestPaymentMethod = await guestPaymentMethodService.Get(id);
        //    if (guestPaymentMethod == null)
        //    {
        //        return NotFound();
        //    }
        //    return guestPaymentMethod;
        //}

        // PUT: api/guestPaymentMethods/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGuestPaymentMethod(int id, GuestPaymentMethodDTO guestPaymentMethod)
        //{
        //    if (id != guestPaymentMethod.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await guestPaymentMethodService.Update(guestPaymentMethod);
        //    return NoContent();
        //}

        // POST: api/guestPaymentMethods
        //[HttpPost]
        //public async Task<ActionResult<GuestPaymentMethodDTO>> PostGuestPaymentMethod(GuestPaymentMethodDTO guestPaymentMethod)
        //{
        //    await guestPaymentMethodService.Create(guestPaymentMethod);
        //    //return CreatedAtAction("GetGuestPaymentMethod", new { id = guestPaymentMethod.Id }, guestPaymentMethod);
        //    return CreatedAtAction(nameof(GetGuestPaymentMethod), new { id = guestPaymentMethod.Id }, guestPaymentMethod);
        //}

        // DELETE: api/guestPaymentMethods/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGuestPaymentMethod(int id)
        //{
        //    await guestPaymentMethodService.Delete(id);
        //    return NoContent();
        //}
    }
}
