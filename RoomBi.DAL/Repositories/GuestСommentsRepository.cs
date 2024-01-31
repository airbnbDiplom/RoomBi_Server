using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class GuestСommentsRepository(RBContext context) : IRepositoryOfAll<GuestСomments>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<GuestСomments>> GetAll()
        {
            return await context.GuestСomments.ToListAsync();
        }
        public async Task<GuestСomments> Get(int id)
        {

            return await context.GuestСomments.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.GuestСomments.FindAsync(id);
        }
        public async Task Create(GuestСomments item)
        {
            await context.GuestСomments.AddAsync(item);
        }
        public async Task Update(GuestСomments item)
        {
            context.GuestСomments.Update(item);
        }
        public async Task Delete(int id)
        {
            GuestСomments? item = await context.GuestСomments.FindAsync(id);
            if (item != null)
                context.GuestСomments.Remove(item);
        }
    }
}
