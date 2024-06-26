﻿using Microsoft.AspNetCore.Authorization;
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

    public class ChatController(
        IServiceCreate<ChatForApartmentPageDTO> chatService,
        IJwtToken jwtTokenService, 
        IServiceBooking<BookingDTO> serviceBooking,
        IServiceGetAllIdUser<MessageObj> serviceChatGetAll,
        IServiceOfAll<GuestComments> serviceOfAll
        ) : ControllerBase
    {
        [Authorize]
        //Post: api/chat s/5
        [HttpPost("GetAllChat")]
        public async Task<ActionResult<List<MessageObj>>> GetAllChat()
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            var fromId = int.Parse(jwtTokenService.GetIdFromToken(principal));
            List<MessageObj> result = await serviceChatGetAll.GetAllObj(fromId);
            //List<MessageObj> result = await serviceChatGetAll.GetAllObj(14);
            return result;
        }
        [Authorize]
        //Post: api/chat s/5
        [HttpPost("messageOnly")]
        public async Task<ActionResult<List<MessageObj>>> MessageOnly([FromBody] ChatForApartmentPageDTO chatForApartmentPageDTO)
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            chatForApartmentPageDTO.FromId = int.Parse(jwtTokenService.GetIdFromToken(principal));
            //chatForApartmentPageDTO.FromId = 14;
            await chatService.Create(chatForApartmentPageDTO);
            return Content("Ok");

        }

        [Authorize]
        //Post: api/chat s/5
        [HttpPost("messageStart")]
        public async Task<ActionResult<List<MessageObj>>> MessageStart([FromBody] MessageStart MessageStart)
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            if (MessageStart.ChatForApartmentPageDTO != null)
            {
                MessageStart.ChatForApartmentPageDTO.FromId = int.Parse(jwtTokenService.GetIdFromToken(principal));
                // MessageStart.ChatForApartmentPageDTO.FromId = 14;
                await chatService.Create(MessageStart.ChatForApartmentPageDTO);
            }
            if (MessageStart.BookingDTO != null)
            {
                MessageStart.BookingDTO.OwnerId = int.Parse(jwtTokenService.GetIdFromToken(principal));
                // MessageStart.BookingDTO.OwnerId = 14;
                await serviceBooking.CreateBookingWithChat(MessageStart.BookingDTO);
            }
            return Content("Ok");

        }


        //POST: api/Chats
        [HttpPost("guestComments")]
        public async Task<ActionResult<GuestComments>> PostChat(GuestComments comment)
        {
            await serviceOfAll.Create(comment);
            return Content("Ok");
        }

        //// GET: api/Chats
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ChatDTO>>> GetChats()
        //{
        //    var chats = await chatService.GetAll();
        //    if (chats == null || !chats.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(chats);
        //}

        // GET: api/chats/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ChatDTO>> GetChat(int id)
        //{
        //    var chat = await chatService.Get(id);
        //    if (chat == null)
        //    {
        //        return NotFound();
        //    }
        //    return chat;
        //}


        // DELETE: api/chat s/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteChat(int id)
        //{
        //    await chatService.Delete(id);
        //    return NoContent();
        //}
    }
}
