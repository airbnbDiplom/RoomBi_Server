using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public interface IRepositoryGetEmail<T> where T : class
    {
        Task<T> GetEmail(string email);
    }
}
