using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class ProfileRepository(RBContext context) : IRepositoryOfAll<Profile>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable< Profile>> GetAll()
        {
            return await context. Profiles.ToListAsync();
        }
        public async Task<Profile> Get(int idUser)
        {

            return await context. Profiles.FirstOrDefaultAsync(m => m.IdUser == idUser);
            //return await context. Profiles.FindAsync(id);
        }
        public async Task Create( Profile item)
        {
            await context. Profiles.AddAsync(item);
        }
        public async Task Update( Profile item)
        {
            context. Profiles.Update(item);
        }
        public async Task Delete(int id)
        {
             Profile? item = await context. Profiles.FindAsync(id);
            if (item != null)
                context. Profiles.Remove(item);
        }
    }
}

