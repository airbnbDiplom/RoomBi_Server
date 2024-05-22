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
    public class ProfileController(IServiceOfAll<ProfileDTO> profileService,
         IJwtToken jwtTokenService, IServiceProfile<ProfileDTO> serviceProfile) : ControllerBase
    {
        [HttpPost]
        public string? GetFirstNonEmptyField(ProfileDTO profile)
        {
            if (!string.IsNullOrEmpty(profile.SchoolYears)) return nameof(profile.SchoolYears);
            if (!string.IsNullOrEmpty(profile.Pets)) return nameof(profile.Pets);
            if (!string.IsNullOrEmpty(profile.Job)) return nameof(profile.Job);
            if (!string.IsNullOrEmpty(profile.MyLocation)) return nameof(profile.MyLocation);
            if (!string.IsNullOrEmpty(profile.MyLanguages)) return nameof(profile.MyLanguages);
            if (!string.IsNullOrEmpty(profile.Generation)) return nameof(profile.Generation);
            if (!string.IsNullOrEmpty(profile.FavoriteSchoolSong)) return nameof(profile.FavoriteSchoolSong);
            if (!string.IsNullOrEmpty(profile.Passion)) return nameof(profile.Passion);
            if (!string.IsNullOrEmpty(profile.InterestingFact)) return nameof(profile.InterestingFact);
            if (!string.IsNullOrEmpty(profile.UselessSkill)) return nameof(profile.UselessSkill);
            if (!string.IsNullOrEmpty(profile.BiographyTitle)) return nameof(profile.BiographyTitle);
            if (!string.IsNullOrEmpty(profile.DailyActivity)) return nameof(profile.DailyActivity);
            if (!string.IsNullOrEmpty(profile.AboutMe)) return nameof(profile.AboutMe);

            return null;
        }

        [Authorize]
        //POST: api/profiles
        [HttpPost("profile")]
        public async Task<ActionResult<ProfileDTO>> PostProfile([FromBody] ProfileDTO profile)
        {
          
            string token = HttpContext.Request.Headers.Authorization; // id из токена
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            profile.IdUser = int.Parse(jwtTokenService.GetIdFromToken(principal));
            //profile.IdUser = 14;
            var item = await profileService.Get(profile.IdUser); // проверяем наличие profile
            if (item == null)                        // если нет
            {
                await profileService.Create(profile);
                return Content("Ok");
            }
            else
            {
                var temp = GetFirstNonEmptyField(profile);
                if (temp == null)                            // если есть но поля пустые
                {
                    await profileService.Delete(item.Id);
                    return Content("Ok");
                }
                else if (temp != null)
                {
                    await serviceProfile.UpdateProfile(temp, profile, profile.IdUser);  // если есть передаем поле для изменения
                    return Content("Ok");
                }
                return Content("Ok");
            }

        }


        [Authorize]
        // GET: api/profiles/5
        [HttpGet("id")]
        public async Task<ActionResult<ProfileDTO>> GetProfile()
        {
            string token = HttpContext.Request.Headers.Authorization; // id из токена
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            int idUser = int.Parse(jwtTokenService.GetIdFromToken(principal));
            //int idUser = 5;
            var profile = await profileService.Get(idUser);
            if (profile == null)
            {
                return NotFound();
            }
            return profile;

        }
    }
}

    // POST: api/profiles
    //[HttpPost]
    //public async Task<ActionResult<ProfileDTO>> PostProfile(ProfileDTO profile)
    //{
    //    await profileService.Create(profile);
    //    return NoContent();
    //}

    //// DELETE: api/profiles/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteProfile(int id)
    //{
    //    await profileService.Delete(id);
    //    return NoContent();
    //}
    //// GET: api/profiles
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<ProfileDTO>>> GetProfiles()
    //{
    //    var profiles = await profileService.GetAll();
    //    if (profiles == null || !profiles.Any())
    //    {
    //        return NotFound();
    //    }
    //    return Ok(profiles);
    //}
  
  