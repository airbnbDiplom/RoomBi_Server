using Azure;
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
        [Authorize]
        [HttpPost("wish")]
        public async Task<ActionResult<WishlistDTO>> PostWishlist([FromBody] int id)
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            try
            {
                int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
                WishlistDTO wishlistDTO = new() { ApartmentId = id, UserId = temp };
                await wishlistService.Create(wishlistDTO);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Ok")
                {
                    var data = new { key = "Ok" };
                    return Ok(data);
                }
                else if (ex.Message == "No")
                {
                    var data = new { key = "No" };
                    return Ok(data);
                }
            }
            return BadRequest("");
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
        //[HttpGet("{id}")]
        //public async Task<ActionResult<WishlistDTO>> GetWishlist(int id)
        //{
        //    //var wishlist = await wishlistService.Get(id);
        //    //if (wishlist == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return wishlist;
        //    return Ok("Ok");
        //}

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
