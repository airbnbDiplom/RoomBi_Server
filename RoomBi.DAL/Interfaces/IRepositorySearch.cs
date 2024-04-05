using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Interfaces
{
    public interface IRepositorySearch<RentalApartment> 
    {
        Task<IEnumerable<RentalApartment>> GetApartmentsByCountryCode(string? countryCode);
        Task<IEnumerable<RentalApartment>> GetApartmentsByCity(int? placeId);

        Task<RentalApartment> GetApartmentsByDateBooking(DateTime start, DateTime end, int? idApartment);
        Task<IEnumerable<RentalApartment>> GetApartmentsByNumberOfGuests(int? why);
        Task<IEnumerable<RentalApartment>> GetAllMinForSearch();
        
        Task<IEnumerable<RentalApartment>> GetFilteredApartments(string? typeAccommodation, 
            string[]? typeOfHousing, int? minimumPrice, int? maximumPrice,
            int? bedrooms, int? beds, int? bathrooms, bool rating,  string[]? offeredAmenitiesDTO,
            string[]? hostsLanguage);
        Task<List<RentalApartment>> GetNearestApartments(string ingMap, string latMap);
    }
}
