using System;
using System.Collections.Generic;
using System.Linq;


namespace RoomBi.DAL.Repositories
{
    public interface IRepositorySearch<RentalApartment> 
    {
        Task<IEnumerable<RentalApartment>> GetObjectForAlex(
            DateTime start, DateTime end, string? type, string? countryCode, int? placeId, int? why, int page = 1, int pageSize = 8);
        Task<IEnumerable<RentalApartment>> GetObjectsByUserId(int? userId);
        Task<IEnumerable<RentalApartment>> GetFilteredApartments(string? typeAccommodation, 
            string[]? typeOfHousing, int? minimumPrice, int? maximumPrice,
            int? bedrooms, int? beds, int? bathrooms, bool rating,  string[]? offeredAmenitiesDTO,
            string[]? hostsLanguage);
        Task<List<RentalApartment>> GetNearestApartments(string ingMap, string latMap);
    }
    public interface IRepositoryGet24<T> where T : class
    {
        Task<IEnumerable<T>> Get24(int page, int pageSize);
    }
}
