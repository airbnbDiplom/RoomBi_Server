using Azure;
using Jose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi_Server.Token;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController(IServiceOfAll<WishlistDTO> wishlistService, IJwtToken jwtTokenService,
        IServiceGetAllIdUser<WishlistDTO> serviceGetAllIdUser,
        IServiceForStartPage<RentalApartmentDTOForStartPage> serviceForStartPage) : ControllerBase
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

        [Authorize]
        [HttpGet("getwishlist")]
        public async Task<ActionResult<AuthenticationResponseDTO>> GetWishlist()
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
            try
            {
                //int temp = 1;
                var wishlist = await serviceGetAllIdUser.GetAllObj(temp);
                if(wishlist == null)
                {
                    return Ok(new List<RentalApartmentDTOForStartPage>());
                }
                List<RentalApartmentDTOForStartPage> rentalApartment = [];

                foreach (var item in wishlist)
                {
                    rentalApartment.Add(await serviceForStartPage.GetCard(item.ApartmentId));
                }
                return Ok(rentalApartment);
            }
            catch
            {
                return BadRequest("");
            }

            //var response = new AuthenticationResponseDTO
            //{
            //    Token = "1",
            //    RefreshToken = "2",
            //    //Profile = user.Profile
            //};
            //return response;
        }

        [Authorize]
        // DELETE: api/wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            try
            {
                int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
                WishlistDTO wishlistDTO = new() { ApartmentId = id, UserId = temp };
                await wishlistService.Update(wishlistDTO);
            }
            catch
            {

            }
            var data = new { key = "Ok-2" };
            return Ok(data);
        }
    }
}
