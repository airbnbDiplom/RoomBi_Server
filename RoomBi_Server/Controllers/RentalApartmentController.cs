using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.Services;
using RoomBi.DAL;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalApartmentController(
        IServiceForStartPage<RentalApartmentDTOForStartPage> serviceForStartPage,
        IServiceForMap<RentalApartmentForMap> serviceForMap,
        IServiceForItem<RentalApartmentDTO> serviceForItem,
        IServiceCreate<TransferDataDTO> serviceCreate ) : ControllerBase
    {
        // GET: api/rentalApartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetRentalApartments(int page = 1, int pageSize = 24, int idUser = 0)
        {
            var rentalApartments = await serviceForStartPage.GetAllForStartPage(page, pageSize, idUser);
            if (rentalApartments == null || !rentalApartments.Any())
            {
                return NotFound();
            }
            return Ok(rentalApartments);
        }
        // GET: api/rentalApartments/map
        [HttpGet("map/{map}")]
        public async Task<ActionResult<IEnumerable<RentalApartmentForMap>>> GetRentalApartments(string map)
        {
            var rentalApartments = await serviceForMap.GetAllForMap(map);
            if (rentalApartments == null || !rentalApartments.Any())
            {
                return NotFound();
            }
            return Ok(rentalApartments);
        }

        // GET: api/rentalApartments/5
        [HttpGet("item/")]
        public async Task<ActionResult<RentalApartmentDTO>> GetRentalApartment(int id, int idUser = 0)
        {
            var rentalApartment = await serviceForItem.GetItem(id, idUser);
            if (rentalApartment == null)
            {
                return NotFound();
            }
            return rentalApartment;
        }
        // POST: api/rentalApartments/{id}
        [HttpPost("card/{id}")]
        public async Task<ActionResult<RentalApartmentDTOForStartPage>> CardRentalApartment(int id)
        {
            var rentalApartment = await serviceForStartPage.GetCard(id);
            if (rentalApartment == null)
            {
                return NotFound();
            }
            return rentalApartment;
        }

    

        //POST: api/rentalApartments
       [HttpPost("create")]
        public async Task<ActionResult<TransferDataDTO>> PostRentalApartment(TransferDataDTO transferDataDTO)
        {
            if(transferDataDTO != null)
            {
                await serviceCreate.Create(transferDataDTO);
                return Content("transferDataDTO");
            }
            return Content("transferDataDTO");
        }

        // DELETE: api/rentalApartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalApartment(int id)
        {
            await serviceForItem.Delete(id);
            return NoContent();
        }



        //POST: api/rentalApartments
        [HttpPost("masterobj")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetAllCardsForMaster(int idMaster)
        {
            IEnumerable<RentalApartmentDTOForStartPage> rentalApartments = await serviceForStartPage.GetAllForMaster(idMaster);
            if (rentalApartments == null || !rentalApartments.Any())
            {
                return NotFound();
            }
            return Ok(rentalApartments);
        }
    }
}
