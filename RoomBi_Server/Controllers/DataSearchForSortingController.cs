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
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting)
        {
            try
            {
                ICollection<RentalApartmentDTOForStartPage>? rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();

                if (dataSearchForSorting.Where.Type != "" || dataSearchForSorting.Where.Type != "string")
                {
                    try
                    {
                        rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.GetAllByType(dataSearchForSorting.Where.Type, dataSearchForSorting.Where.Name);

                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                if (dataSearchForSorting.When.Start.Day != 0)
                {
                    try
                    {
                        if (rentalApartmentDTO.Count == 0)
                        {
                            rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.DateBookingSearch(dataSearchForSorting.When, rentalApartmentDTO = null);
                        }
                        else
                        {
                            rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.DateBookingSearch(dataSearchForSorting.When, rentalApartmentDTO);
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                if (dataSearchForSorting.Why != 0)
                {
                    try
                    {
                        if (rentalApartmentDTO.Count == 0)
                        {
                            rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.GetAllByNumberOfGuests(dataSearchForSorting.Why, rentalApartmentDTO = null);
                        }
                        else
                        {
                            rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.GetAllByNumberOfGuests(dataSearchForSorting.Why, rentalApartmentDTO);
                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                return Ok(rentalApartmentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //return Ok("Ok");
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCardsForMax([FromBody] Filter filter)
        {
            try
            {
                ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();
                if (filter != null)
                {
                    try
                    {
                        var rentalApartments = await serviceForStartPage.GetAllForStartPage();
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
    }
}

