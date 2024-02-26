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
        //Task<T> GetByEmailAndPassword(string email, string password);
        Task<Boolean> GetBoolByEmail(string email);
        Task<Boolean> GetBoolByPassword(string password);
        Task<T> GetUserByEmail(string email);
        Task UpdateRefreshToken(T item);

    }
}
