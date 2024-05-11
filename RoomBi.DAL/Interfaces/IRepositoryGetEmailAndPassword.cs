
namespace RoomBi.DAL.Repositories
{
    public interface IRepositoryGetEmailAndPassword<T> where T : class
    {
        Task<T> GetEmail(string email);
        Task<T> GetPassword(string password);
    }
}
