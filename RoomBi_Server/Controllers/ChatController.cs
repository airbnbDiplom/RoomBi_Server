using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi_Server.Token;
using System.Security.Claims;



namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChatController(
        IServiceChat<ChatForApartmentPageDTO> chatService,
        IJwtToken jwtTokenService, 
        IServiceBooking<BookingDTO> serviceBooking,
        IServiceChatGetAll<MessageObj> serviceChatGetAll



        ) : ControllerBase
    {
        //[Authorize]
        //Post: api/chat s/5
        [HttpPost("messageStart")]
        public async Task<ActionResult<List<MessageObj>>> PutChat([FromBody] MessageStart MessageStart)
        {
            //    string token = HttpContext.Request.Headers.Authorization;
            //    string cleanedToken = token.Replace("Bearer ", "");
            //    ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            //if (MessageStart.ChatForApartmentPageDTO!=null)
            //{
            //    //MessageStart.ChatForApartmentPageDTO.GuestIdUser = int.Parse(jwtTokenService.GetIdFromToken(principal));

            //    MessageStart.ChatForApartmentPageDTO.GuestIdUser = 1;
            //    await chatService.Create(MessageStart.ChatForApartmentPageDTO);
            //}
            //if (MessageStart.BookingDTO != null)
            //{
            //    await serviceBooking.CreateBookingWithChat(MessageStart.BookingDTO);
            //}
            List<MessageObj> result = await serviceChatGetAll.GetAllChatObj(5);

            return result;
         
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
        // POST: api/Chats
        //[HttpPost]
        //public async Task<ActionResult<ChatDTO>> PostChat(ChatDTO chat)
        //{
        //    await chatService.Create(chat);
        //    //return CreatedAtAction("GetChat", new { id = chat .Id }, chat );
        //    return CreatedAtAction(nameof(GetChat), new { id = chat.Id }, chat);
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
