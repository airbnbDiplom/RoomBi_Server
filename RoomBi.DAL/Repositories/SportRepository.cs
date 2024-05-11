using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;

namespace RoomBi.DAL.Repositories
{
    public class SportRepository(RBContext context) : IRepositoryOfAll<Sport>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<Sport>> GetAll()
        {
            return await context.Sports.ToListAsync();
        }
        public async Task<Sport> Get(int id)
        {

            return await context.Sports.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.PropertyTypes.FindAsync(id);
        }
        public async Task Create(Sport item)
        {
            await context.Sports.AddAsync(item);
        }
        public async Task Update(Sport item)
        {
            context.Sports.Update(item);
        }
        public async Task Delete(int id)
        {
            Sport? item = await context.Sports.FindAsync(id);
            if (item != null)
                context.Sports.Remove(item);
        }
    }
}
