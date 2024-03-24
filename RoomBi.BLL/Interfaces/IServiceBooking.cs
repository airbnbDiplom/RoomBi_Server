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
        Task CreateBooking(T item);
        Task CreateBookingWithChat(T item);
    }
    public interface IServiceChat<T>
    {
        Task Create(T item);
    }
    public interface IServiceChatGetAll<T>
    {
        Task<List<T>> GetAllChatObj(int GuestIdUser);
    }
}
