using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;

namespace RoomBi.DAL.Repositories
{
    public class UserRepository: IRepositoryOfAll<User>, IRepositoryGetEmailAndPassword<User>
    {
        private readonly RBContext context;

        public UserRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> Get(int id)
        {
            
 var user =  await context.Users.FirstOrDefaultAsync(m => m.Id == id);
            return user;
             
        }

        public async Task<User> GetEmail(string email)
        {
            return await context.Users.FirstOrDefaultAsync(m => m.Email == email);
        }
        public async Task<User> GetPassword(string password)
        {
            return await context.Users.FirstOrDefaultAsync(m => m.Password == password);
        }
        public async Task Create(User item)
        {
            await context.Users.AddAsync(item);
        }
        public async Task Update(User item)
        {
            context.Users.Update(item); await context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            User? item = await context.Users.FindAsync(id);
            if (item != null)
                context.Users.Remove(item);
        }
    }
}

