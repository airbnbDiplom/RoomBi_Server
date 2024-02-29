using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public interface IRepositoryOfAll<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
    public interface IRepositoryGet24<T> where T : class
    {
        Task<IEnumerable<T>> Get24(int page, int pageSize);
    }
    public interface IRepositoryGetWishlictitem<T> where T : class
    {
        Task<Boolean> CheckIfWishlistItemExists(int userId, int apartId);
    }
    public interface IRepositoryForApartment<T> where T : class
    {
        Task<IEnumerable<T>> ByApartmentId(int apartmentId);
    }
}
