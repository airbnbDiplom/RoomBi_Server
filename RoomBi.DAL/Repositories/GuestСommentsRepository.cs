using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class GuestCommentsRepository(RBContext context) : IRepositoryOfAll<GuestComments>, IRepositoryGetAllByID<GuestComments>
    {
        private readonly RBContext context = context;
        public async Task<IEnumerable<GuestComments>> GetAllById(int apartmentId)// коллекция для определенной квартиры
        {
            return await context.GuestComments
                    .Where(guestComment => guestComment.ApartmentId == apartmentId)
                    .ToListAsync();

        }
        public async Task<IEnumerable<GuestComments>> GetAll()
        {
            return await context.GuestComments.ToListAsync();
        }
        public async Task<GuestComments> Get(int id)
        {

            return await context.GuestComments.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.GuestСomments.FindAsync(id);
        }
        public async Task Create(GuestComments item)
        {
            await context.GuestComments.AddAsync(item);
        }
        public async Task Update(GuestComments item)
        {
            context.GuestComments.Update(item);
        }
        public async Task Delete(int id)
        {
            GuestComments? item = await context.GuestComments.FindAsync(id);
            if (item != null)
                context.GuestComments.Remove(item);
        }
    }
}
