using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

//namespace RoomBi_Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PictureController(IServiceOfAll<PictureDTO> pictureService) : ControllerBase
//    {
//        // GET: api/pictures
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<PictureDTO>>> GetPictures()
//        {
//            var pictures = await pictureService.GetAll();
//            if (pictures == null || !pictures.Any())
//            {
//                return NotFound();
//            }
//            return Ok(pictures);
//        }

//        // GET: api/pictures/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<PictureDTO>> GetPicture(int id)
//        {
//            var picture = await pictureService.Get(id);
//            if (picture == null)
//            {
//                return NotFound();
//            }
//            return picture;
//        }

//        // PUT: api/pictures/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPicture(int id, PictureDTO picture)
//        {
//            if (id != picture.Id)
//            {
//                return BadRequest();
//            }
//            await pictureService.Update(picture);
//            return NoContent();
//        }

//        // POST: api/pictures
//        [HttpPost]
//        public async Task<ActionResult<PictureDTO>> PostPicture(PictureDTO picture)
//        {
//            await pictureService.Create(picture);
//            //return CreatedAtAction("GetPicture", new { id = picture.Id }, picture);
//            return CreatedAtAction(nameof(GetPicture), new { id = picture.Id }, picture);
//        }

//        // DELETE: api/pictures/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePicture(int id)
//        {
//            await pictureService.Delete(id);
//            return NoContent();
//        }
//    }
//}
