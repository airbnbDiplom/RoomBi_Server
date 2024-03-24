using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.Services;
using RoomBi.DAL;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataSearchForSortingController(
        IServiceForStartPage<RentalApartmentDTOForStartPage> serviceForStartPage,
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage> forSorting) : ControllerBase
    {
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting, int page = 1, int pageSize = 8)
        {
            try
            {
                ICollection<RentalApartmentDTOForStartPage>? rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();

                if (dataSearchForSorting?.Where != null)
                {
                    try
                    {
                        rentalApartmentDTO = (ICollection<RentalApartmentDTOForStartPage>)await forSorting.GetAllByType(dataSearchForSorting.Where);

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
                if (rentalApartmentDTO.Count != 0)
                {
                    int totalItems = rentalApartmentDTO.Count;
                    int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                    if (page > totalPages)
                    {
                        return Ok(new List<RentalApartmentDTOForStartPage>());
                    }
                    int startIndex = (page - 1) * pageSize;
                    var pageApartments = rentalApartmentDTO.Skip(startIndex).Take(pageSize);
                    return Ok(pageApartments);
                }
                else
                {
                    // Возвращаем пустую коллекцию, если нет объектов
                    return Ok(new List<RentalApartmentDTOForStartPage>());
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            //var rentalApartments = await serviceForStartPage.GetAllForStartPage();
            //return Ok(rentalApartments);
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
                        var rentalApartments2 = await forSorting.GetAllByFilter(filter);

                        return Ok(rentalApartments2);
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

