using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Interfaces
{
    public interface IServiceDataSearchForSorting<T> where T : class
    {
        Task<IEnumerable<T>> GetAllByFilter(Filter filter);
        Task<IEnumerable<T>> GetNearestRooms(string ingMap, string latMap); 
        Task<IEnumerable<T>> AlexSearch(DataSearchForSorting dataSearchForSorting, int page, int pageSize);
    }
} 





