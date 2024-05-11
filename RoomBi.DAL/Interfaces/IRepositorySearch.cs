using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Interfaces
{
    public interface IRepositorySearch<RentalApartment> 
    {
        Task<IEnumerable<RentalApartment>> GetObjectByTwoStringAndTwoInt(
            DateTime start, DateTime end, string? type, string? countryCode, int? placeId, int? why, int page = 1, int pageSize = 8);
        Task<IEnumerable<RentalApartment>> GetObjectsByUserId(int? userId);
        Task<IEnumerable<RentalApartment>> GetFilteredApartments(string? typeAccommodation, 
            string[]? typeOfHousing, int? minimumPrice, int? maximumPrice,
            int? bedrooms, int? beds, int? bathrooms, bool rating,  string[]? offeredAmenitiesDTO,
            string[]? hostsLanguage);
        Task<List<RentalApartment>> GetNearestApartments(string ingMap, string latMap);
    }
}
//Task<RentalApartment> GetApartmentsByDateBooking(DateTime start, DateTime end, int? idApartment);
//Task<IEnumerable<RentalApartment>> GetApartmentsByNumberOfGuests(int? why);
//Task<IEnumerable<RentalApartment>> GetAllMinForSearch();
//Task<IEnumerable<RentalApartment>> GetApartmentsByCity(int? placeId);