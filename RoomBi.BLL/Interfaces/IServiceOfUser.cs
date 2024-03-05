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
        Boolean GetBoolByPassword(string password, string password2);
        Task<T> GetUserByEmail(string email);
        Task UpdateRefreshToken(T item);
    
    }
    public interface IServiceOfUserGoogle<T>
    {
    
        Task<T> GetUserByGoogle(RequestUser item);
    }

}
