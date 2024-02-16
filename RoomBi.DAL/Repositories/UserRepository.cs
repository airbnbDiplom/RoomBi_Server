using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class UserRepository(RBContext context) : IRepositoryOfAll<User>, IRepositoryUser<User>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> Get(int id)
        {

            return await context.Users.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Users.FindAsync(id);
        }

        public async Task<User> GetEmail(string email)
        {

            return await context.Users.FirstOrDefaultAsync(m => m.Email == email);
        }

        public async Task Create(User item)
        {
            await context.Users.AddAsync(item);
        }
        public async Task Update(User item)
        {
            context.Users.Update(item);
        }
        public async Task Delete(int id)
        {
            User? item = await context.Users.FindAsync(id);
            if (item != null)
                context.Users.Remove(item);
        }
    }
}

