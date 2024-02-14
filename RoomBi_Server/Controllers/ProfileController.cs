using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

//namespace RoomBi_Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProfileController(IServiceOfAll<ProfileDTO> profileService) : ControllerBase
//    {
//        // GET: api/profiles
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ProfileDTO>>> GetProfiles()
//        {
//            var profiles = await profileService.GetAll();
//            if (profiles == null || !profiles.Any())
//            {
//                return NotFound();
//            }
//            return Ok(profiles);
//        }

//        // GET: api/profiles/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<ProfileDTO>> GetProfile(int id)
//        {
//            var profile = await profileService.Get(id);
//            if (profile == null)
//            {
//                return NotFound();
//            }
//            return profile;
//        }

//        // PUT: api/profiles/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProfile(int id, ProfileDTO profile)
//        {
//            if (id != profile.Id)
//            {
//                return BadRequest();
//            }
//            await profileService.Update(profile);
//            return NoContent();
//        }

//        // POST: api/profiles
//        [HttpPost]
//        public async Task<ActionResult<ProfileDTO>> PostProfile(ProfileDTO profile)
//        {
//            await profileService.Create(profile);
//            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
//        }

//        // DELETE: api/profiles/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProfile(int id)
//        {
//            await profileService.Delete(id);
//            return NoContent();
//        }
//    }
//}