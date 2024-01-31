using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
 

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(IServiceOfAll<LanguageDTO> languageService) : ControllerBase
    {
        // GET: api/Languages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageDTO>>> GetLanguages()
        {
            var languages = await languageService.GetAll();
            if (languages == null || !languages.Any())
            {
                return NotFound();
            }
            return Ok(languages);
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageDTO>> GetLanguage(int id)
        {
            var language = await languageService.Get(id);
            if (language == null)
            {
                return NotFound();
            }
            return language;
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, LanguageDTO language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }
            await languageService.Update(language);
            return NoContent();
        }

        // POST: api/Languages
        [HttpPost]
        public async Task<ActionResult<LanguageDTO>> PostLanguage(LanguageDTO language)
        {
            await languageService.Create(language);
            return CreatedAtAction(nameof(GetLanguage), new { id = language.Id }, language);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await languageService.Delete(id);
            return NoContent();
        }
    }
}
