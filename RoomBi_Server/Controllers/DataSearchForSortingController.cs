using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.Services;
using RoomBi.DAL;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSearchForSortingController(
        IServiceForStartPage<RentalApartmentDTOForStartPage> serviceForStartPage,
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage> forSorting) : ControllerBase
    {
        // GET: api/dataSearchForSortingController
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting)
        {
            try
            {
                ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();

                if (dataSearchForSorting.Where.Type != null)
                {
                    try
                    {
                        rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.GetAllByType(dataSearchForSorting.Where.Type, dataSearchForSorting.Where.Name);
                        return Ok(rentalApartmentDTO);
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

            //await forSorting.GetAllByType("qwertyu");
            // //var users = await forSorting.TempGetAll();
            // if (dataSearchForSorting == null)
            // {
            //     return NotFound();
            // }
            return Ok("Не попал в свич");
        }
    }
}
