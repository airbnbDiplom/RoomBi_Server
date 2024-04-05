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
        IServiceForSorting<RentalApartmentDTOForStartPage> serviceForSorting,
        IServiceDataSearchForSorting<RentalApartment> forSorting) : ControllerBase
    {
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOForStartPage>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting, int page = 1, int pageSize = 8)
        {
            try
            {
                IEnumerable<RentalApartment> rentalApartment = new List<RentalApartment>();
                if (dataSearchForSorting?.Where != null)
                {
                    try
                    {
                        rentalApartment = await forSorting.GetAllByType(dataSearchForSorting.Where);
                        if (rentalApartment.Count() == 0)
                        {
                            return Ok(new List<RentalApartmentDTOForStartPage>());
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
                        if (rentalApartment.Count() == 0)
                        {
                            rentalApartment = await forSorting.GetAllByNumberOfGuests(dataSearchForSorting.Why, rentalApartment = null);
                            if (rentalApartment.Count() == 0)
                            {
                                return Ok(new List<RentalApartmentDTOForStartPage>());
                            }
                        }
                        else
                        {
                            rentalApartment = await forSorting.GetAllByNumberOfGuests(dataSearchForSorting.Why, rentalApartment);
                            if (rentalApartment.Count() == 0)
                            {
                                return Ok(new List<RentalApartmentDTOForStartPage>());
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                try
                {
                    if (rentalApartment.Count() == 0)
                    {
                        rentalApartment = await forSorting.DateBookingSearch(dataSearchForSorting.When, rentalApartment = null);
                    }
                    else
                    {
                        rentalApartment = await forSorting.DateBookingSearch(dataSearchForSorting.When, rentalApartment);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


              
                int totalItems = rentalApartment.Count();
                if (totalItems != 0)
                {
                    int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                    if (page > totalPages)
                    {
                        return Ok(new List<RentalApartmentDTOForStartPage>());
                    }
                    int startIndex = (page - 1) * pageSize;
                    var pageApartments = rentalApartment.Skip(startIndex).Take(pageSize);
                    List<RentalApartmentDTOForStartPage> rentalApartmentResult = [];
                    foreach (var item in pageApartments)
                    {
                        rentalApartmentResult.Add(await serviceForSorting.NewRentalApartment(item));
                    }

                    return Ok(rentalApartmentResult);
            
                }
                else
                {
                    return Ok(new List<RentalApartmentDTOForStartPage>());
                }
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
                        var rentalApartments = await forSorting.GetAllByFilter(filter);
                        List<RentalApartmentDTOForStartPage> rentalApartmentResult = [];
                        foreach (var item in rentalApartments)
                        {
                            rentalApartmentResult.Add(await serviceForSorting.NewRentalApartment(item));
                        }
                        return Ok(rentalApartmentResult);
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
                var rentalApartments = await forSorting.GetNearestRooms(ingMap, latMap);
                List<RentalApartmentDTOForStartPage> rentalApartmentResult = [];
                foreach (var item in rentalApartments)
                {
                    rentalApartmentResult.Add(await serviceForSorting.NewRentalApartment(item));
                }
                return Ok(rentalApartmentResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Ok");
        }
    }
}

