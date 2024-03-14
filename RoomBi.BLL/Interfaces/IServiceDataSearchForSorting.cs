using RoomBi.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceDataSearchForSorting<T> where T : class
    {
        Task<IEnumerable<T>> GetAllByType(Where where);
        Task<IEnumerable<T>> DateBookingSearch(DateBooking booking, ICollection<RentalApartmentDTOForStartPage>? rentalApartmentDTO = null);
        Task<IEnumerable<T>> GetAllByNumberOfGuests(int? why, ICollection<RentalApartmentDTOForStartPage>? rentalApartmentDTO = null);
        Task<IEnumerable<T>> GetAllByFilter(Filter filter);
    }
}
