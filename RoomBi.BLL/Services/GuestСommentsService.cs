
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RoomBi.BLL.Services
{

    public class GuestСommentsService(IUnitOfWork uow) : IServiceOfAll<GuestComments>
    {
        public async Task<IEnumerable<GuestComments>> GetAll()
        {
            return await Database.GuestComments.GetAll();
        }
        IUnitOfWork Database { get; set; } = uow;

        public async Task Create(GuestComments guestСomments)
        {
            await Database.GuestComments.Create(guestСomments);
            await Database.Save();
        }

        public async Task Update(GuestComments guestСomments)
        {
            await Database.GuestComments.Update(guestСomments);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.GuestComments.Delete(id);
            await Database.Save();
        }

        public async Task<GuestComments> Get(int id)
        {
            var guestСomments = await Database.GuestComments.Get(id);
            if (guestСomments == null)
                throw new ValidationException("Wrong guestСomments!");
            return guestСomments;
        }


    }
}
