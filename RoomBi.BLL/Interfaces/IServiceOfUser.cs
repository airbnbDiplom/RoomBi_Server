using RoomBi.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceOfUser<T>
    {
        Task<T> GetByEmailAndPassword(string email, string password);
        Task<T> RegisterByEmailAndPassword(string email, string password);
        Task<Boolean> GetBoolByEmail(string email);
        Task<T> GetUserByEmail(string email);
        Task UpdateRefreshToken(T item);

    }
}
