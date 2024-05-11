using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceForStartPage<T>
    {
        Task<IEnumerable<T>> GetAllForStartPage(int page = 1, int pageSize = 24, int idUser = 0);
        Task<T> GetCard(int id);
    }
    public interface IServiceForItem<T>
    {
        Task<T> GetItem(int id, int userId);
    }
    public interface IServiceForMap<T>
    {
        Task<IEnumerable<T>> GetAllForMap(string map);
    }
}
