
namespace RoomBi.DAL.Repositories
{
    public interface IRepositoryGetName<T> where T : class
    {
        Task<T> GetByName(string name);
    }
}
