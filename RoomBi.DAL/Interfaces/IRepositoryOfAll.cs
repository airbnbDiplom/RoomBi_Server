using System;
using System.Collections;
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
    public interface IRepositoryGetWishlictitem<T> where T : class
    {
        Task<Boolean> CheckIfWishlistItemExists(int userId, int apartId);
        Task DeleteIfWishlistItem(int userId, int apartId);
    }
    public interface IRepositoryGetAllByID<T> where T : class
    {
        Task<IEnumerable<T>> GetAllById(int Id);
    }
    public interface IRepositoryForChat<T> where T : class
    {
        Task<List<List<T>>> GetAllChat(int user);
    }
   
}
