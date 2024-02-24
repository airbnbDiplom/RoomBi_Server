using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(IServiceOfAll<WishlistDTO> wishlistService) : ControllerBase
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

        //// POST: api/wishlists
        //[HttpPost]
        //public async Task<ActionResult<WishlistDTO>> PostWishlist(WishlistDTO wishlist)
        //{
        //    await wishlistService.Create(wishlist);
        //    return CreatedAtAction(nameof(GetWishlist), new { id = wishlist.Id }, wishlist);
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
