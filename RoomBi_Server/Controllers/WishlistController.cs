using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi_Server.Token;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(IServiceOfAll<WishlistDTO> wishlistService, IJwtToken jwtTokenService, IServiceOfUser<UserDTO> serviceOfUser) : ControllerBase
    {
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
        //    var wishlist = await wishlistService.Get(id);
        //    if (wishlist == null)
        //    {
        //        return NotFound();
        //    }
        //    return wishlist;
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

        // POST: api/wishlists
        [Authorize]
        [HttpPost]
        public /*async*/ Task<ActionResult<WishlistDTO>> PostWishlist(int id)
        {
            var token = HttpContext.Request.Headers.Authorization;
            var principal = jwtTokenService.GetPrincipalFromExpiredToken(token);
            //principal.Claims.Id;
            //var principal = jwtTokenService.GetPrincipalFromExpiredToken(token.);
            //var email = jwtTokenService.GetMailFromToken(principal);
            //var user = await serviceOfUser.GetUserByEmail(email);
            //await wishlistService.Create(wishlist);
            return null;//CreatedAtAction(nameof(GetWishlist), new { id = wishlist.Id }, wishlist);
        }

        //// DELETE: api/wishlists/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWishlist(int id)
        //{
        //    await wishlistService.Delete(id);
        //    return NoContent();
        //}
    }
}
