using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class GuestCommentsRepository(RBContext context) : IRepositoryOfAll<GuestComments>
    {
        private readonly RBContext context = context;
        public IEnumerable<GuestComments> GetGuestCommentsByApartmentId(int apartmentId)// коллекция для определенной квартиры
        {
            return context.GuestСomments
                .Where(guestComment => guestComment.ApartmentId == apartmentId)
                .ToList();
        }
        public async Task<IEnumerable<GuestComments>> GetAll()
        {
            return await context.GuestСomments.ToListAsync();
        }
        public async Task<GuestComments> Get(int id)
        {

            return await context.GuestСomments.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.GuestСomments.FindAsync(id);
        }
        public async Task Create(GuestComments item)
        {
            await context.GuestСomments.AddAsync(item);
        }
        public async Task Update(GuestComments item)
        {
            context.GuestСomments.Update(item);
        }
        public async Task Delete(int id)
        {
            GuestComments? item = await context.GuestСomments.FindAsync(id);
            if (item != null)
                context.GuestСomments.Remove(item);
        }
    }
}
