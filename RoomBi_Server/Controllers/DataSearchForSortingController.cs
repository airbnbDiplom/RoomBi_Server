
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSearchForSortingController(
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage> searchForSorting
        ) : ControllerBase
    {
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting, int page = 1, int pageSize = 8)
        {
            try
            {
                IEnumerable<RentalApartmentDTOForStartPage> rentalApartmentQuery = await searchForSorting.AlexSearch(dataSearchForSorting, page = 1, pageSize = 8);
                if (!rentalApartmentQuery.Any())
                {
                    return Ok(new List<RentalApartmentDTOForStartPage>());
                }
                return Ok(rentalApartmentQuery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCardsForMax([FromBody] Filter filter)
        {
            try
            {
                if (filter != null)
                {
                    try
                    {
                        var rentalApartments = await searchForSorting.GetAllByFilter(filter);
                        return Ok(rentalApartments);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Ok");
        }

        [HttpPost("coordinates")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetNearestApartments(string ingMap, string latMap)
        {
            try
            {
                var rentalApartments = await searchForSorting.GetNearestRooms(ingMap, latMap);
                return Ok(rentalApartments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

