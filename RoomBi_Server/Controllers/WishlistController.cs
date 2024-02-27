using Jose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi_Server.Token;
using System.Security.Claims;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(IServiceOfAll<WishlistDTO> wishlistService, IJwtToken jwtTokenService) : ControllerBase
    {

        // POST: api/wishlists
        //[Authorize]
        [HttpPost("wish")]
        public async Task<ActionResult<WishlistDTO>> PostWishlist([FromBody] int id, string tokentest)
        { 
            //var token = HttpContext.Request.Headers.Authorization;
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(tokentest);
            //string idString = jwtTokenService.GetIdFromToken(principal);
            try
            {
                int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
                WishlistDTO wishlistDTO = new() { ApartmentId = id, UserId = temp };
            }
            catch (FormatException ex)
            {
                // Обработка ситуации, когда строка не может быть преобразована в int
                return BadRequest("Неверный формат ID");
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                return BadRequest("Произошла ошибка при обработке ID");
            }

            //if (int.TryParse(idString, out int temp))
            //{
            //    WishlistDTO wishlistDTO = new() { ApartmentId = id, UserId = temp};
            //}
            //else
            //{
            //    // Обработка ситуации, когда строка не может быть преобразована в int
            //}
           
            //await wishlistService.Create(wishlistDTO);
            var response = new AuthenticationResponseDTO
            {
                Token = "token",
                RefreshToken = id.ToString(),
            };
            return Ok(response);

        }



        //// GET: api/wishlists
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<WishlistDTO>>> GetWishlists()
        //{
        //    var wishlists = await wishlistService.GetAll();
        //    if (wishlists == null || !wishlists.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(wishlists);
        //}

        //// GET: api/wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WishlistDTO>> GetWishlist(int id)
        {
            //var wishlist = await wishlistService.Get(id);
            //if (wishlist == null)
            //{
            //    return NotFound();
            //}
            //return wishlist;
            return Ok("Ok");
        }

        //// PUT: api/wishlists/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWishlist(int id, WishlistDTO wishlist)
        //{
        //    if (id != wishlist.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await wishlistService.Update(wishlist);
        //    return NoContent();
        //}



        //// DELETE: api/wishlists/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWishlist(int id)
        //{
        //    await wishlistService.Delete(id);
        //    return NoContent();
        //}
    }
}
