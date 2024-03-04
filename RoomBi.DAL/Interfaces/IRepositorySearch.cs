using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Interfaces
{
    public interface IRepositorySearch<RentalApartment> /*where T : class*/
    {
        Task<IEnumerable<RentalApartment>> GetApartmentsByContinent(string continent);
        Task<IEnumerable<RentalApartment>> GetApartmentsByCountry(string country);
        Task<IEnumerable<RentalApartment>> GetApartmentsByCity(string city);
        Task<RentalApartment> GetApartmentsByDateBooking(DateTime start, DateTime end, int idApartment);
        Task<IEnumerable<RentalApartment>> GetAllMinForSearch();
        Task<IEnumerable<RentalApartment>> GetApartmentsByNumberOfGuests(int why);
    }
}
