using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Interfaces
{
    public interface IRepositorySearch<T> where T : class
    {
        Task<IEnumerable<RentalApartment>> GetApartmentsByContinent(string continent);
        Task<IEnumerable<RentalApartment>> GetApartmentsByCountry(string country);
    }
}
