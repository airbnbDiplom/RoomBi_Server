
namespace RoomBi.BLL.Interfaces
{
    public interface IServiceForStartPage<T>
    {
        Task<IEnumerable<T>> GetAllForStartPage(int page = 1, int pageSize = 24, int idUser = 0);
        Task<T> GetCard(int id);
        Task<IEnumerable<T>> GetAllForMaster(int idUser);
    }
    public interface IServiceForItem<T>
    {
        Task<T> GetItem(int id, int userId);
        Task Delete(int id);

    }
    public interface IServiceForMap<T>
    {
        Task<IEnumerable<T>> GetAllForMap(string map);
    }
}
