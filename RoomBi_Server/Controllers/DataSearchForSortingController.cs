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
        IServiceDataSearchForSorting<RentalApartment> forSorting,
        IServiceForSorting<RentalApartmentDTOWithBooking> serviceForSorting1
        ) : ControllerBase
    {
        [HttpPost("sort")]
        public async Task<ActionResult<IEnumerable<RentalApartmentDTOWithBooking>>> GetCards([FromBody] DataSearchForSorting dataSearchForSorting, int page = 1, int pageSize = 8)
        {
            try
            {
                IEnumerable<RentalApartment> rentalApartmentQuery = await forSorting.DateBookingSearch();
                if (dataSearchForSorting?.Where.Type == "country")
                {
                    rentalApartmentQuery = rentalApartmentQuery.Where(r => r.CountryCode == dataSearchForSorting.Where.CountryCode);
                }
                else 
                {
                    rentalApartmentQuery = rentalApartmentQuery.Where(r => r.PlaceId == dataSearchForSorting.Where.PlaceId);
                }

                rentalApartmentQuery = rentalApartmentQuery.Where(r => r.NumberOfGuests == dataSearchForSorting.Why);  
            int totalItems = rentalApartmentQuery.Count();
            if (totalItems == 0)
            {
                return Ok(new List<RentalApartmentDTOWithBooking>());
            }
          //      int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

          //      if (page > totalPages)
          //      {
          //          return Ok(new List<RentalApartmentDTOWithBooking>());
          //      }

          //      int startIndex = (page - 1) * pageSize;
          //      var pageApartments = rentalApartmentQuery
          //.OrderBy(r => r.Id)
          //.Skip(startIndex)
          //.Take(pageSize);


                var rentalApartmentResult = new List<RentalApartmentDTOWithBooking>();
            foreach (var item in rentalApartmentQuery)
            {
                rentalApartmentResult.Add(await serviceForSorting1.NewRentalApartment(item));
            }

            return Ok(rentalApartmentResult);
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

