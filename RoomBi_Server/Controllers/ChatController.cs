using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;



//namespace RoomBi_Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChatController(IServiceOfAll<ChatDTO> chatService) : ControllerBase
//    {
//        // GET: api/Chats
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ChatDTO>>> GetChats()
//        {
//            var chats = await chatService.GetAll();
//            if (chats == null || !chats.Any())
//            {
//                return NotFound();
//            }
//            return Ok(chats);
//        }

//        // GET: api/chats/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ChatDTO>> GetChat(int id)
//        {
//            var chat = await chatService.Get(id);
//            if (chat == null)
//            {
//                return NotFound();
//            }
//            return chat;
//        }

//        // PUT: api/chat s/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutChat(int id, ChatDTO chat )
//        {
//            if (id != chat.Id)
//            {
//                return BadRequest();
//            }
//            await chatService.Update(chat);
//            return NoContent();
//        }

//        // POST: api/Chats
//        [HttpPost]
//        public async Task<ActionResult<ChatDTO>> PostChat(ChatDTO chat )
//        {
//            await chatService.Create(chat );
//            //return CreatedAtAction("GetChat", new { id = chat .Id }, chat );
//            return CreatedAtAction(nameof(GetChat), new { id = chat .Id }, chat );
//        }

//        // DELETE: api/chat s/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteChat(int id)
//        {
//            await chatService.Delete(id);
//            return NoContent();
//        }
//    }
//}
