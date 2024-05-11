using RoomBi.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceBooking<T>
    {
        Task CreateBookingWithChat(T item);
    }
    public interface IServiceCreate<T>
    {
        Task Create(T item);
    }
    public interface IServiceGetAllIdUser<T>
    {
        Task<List<T>> GetAllObj(int IdUser);
    }
}
