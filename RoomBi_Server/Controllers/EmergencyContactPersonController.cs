using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyContactPersonsController(IServiceOfAll<EmergencyContactPersonDTO> emergencyContactPersonService) : ControllerBase
    {
        // GET: api/emergencyContactPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmergencyContactPersonDTO>>> GetEmergencyContactPersons()
        {
            var emergencyContactPersons = await emergencyContactPersonService.GetAll();
            if (emergencyContactPersons == null || !emergencyContactPersons.Any())
            {
                return NotFound();
            }
            return Ok(emergencyContactPersons);
        }

        // GET: api/emergencyContactPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmergencyContactPersonDTO>> GetEmergencyContactPerson(int id)
        {
            var emergencyContactPerson = await emergencyContactPersonService.Get(id);
            if (emergencyContactPerson == null)
            {
                return NotFound();
            }
            return emergencyContactPerson;
        }

        // PUT: api/emergencyContactPersons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmergencyContactPerson(int id, EmergencyContactPersonDTO emergencyContactPerson)
        {
            if (id != emergencyContactPerson.Id)
            {
                return BadRequest();
            }
            await emergencyContactPersonService.Update(emergencyContactPerson);
            return NoContent();
        }

        // POST: api/emergencyContactPersons
        [HttpPost]
        public async Task<ActionResult<EmergencyContactPersonDTO>> PostEmergencyContactPerson(EmergencyContactPersonDTO emergencyContactPerson)
        {
            await emergencyContactPersonService.Create(emergencyContactPerson);
            //return CreatedAtAction("GetEmergencyContactPerson", new { id = emergencyContactPerson.Id }, emergencyContactPerson);
            return CreatedAtAction(nameof(GetEmergencyContactPerson), new { id = emergencyContactPerson.Id }, emergencyContactPerson);
        }

        // DELETE: api/emergencyContactPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelEteemergencyContactPerson(int id)
        {
            await emergencyContactPersonService.Delete(id);
            return NoContent();
        }
    }
}
