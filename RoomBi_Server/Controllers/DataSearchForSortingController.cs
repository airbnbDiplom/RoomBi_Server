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
    public class DataSearchForSortingController(IServiceDataSearchForSorting<RentalApartmentDTOForStartPage> forSorting) : ControllerBase
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
                    switch (dataSearchForSorting.Where.Type)
                    {
                        case "Country":
                            try
                            {
                                return Ok("Ok");
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }
                        case "Сontinent":
                            try
                            {
                                return Ok("Ok");
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }
                        case "City":
                            try
                            {
                                return Ok("Ok");
                            }
                            catch (Exception ex)
                            {
                                return BadRequest(ex.Message);
                            }
                        default:
                            return BadRequest("Invalid request type");
                    }

                }
               

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         






           await forSorting.TempGetAll("qwertyu");
            //var users = await forSorting.TempGetAll();
            if (dataSearchForSorting == null)
            {
                return NotFound();
            }
            return Ok(dataSearchForSorting);
        }
    }
}
