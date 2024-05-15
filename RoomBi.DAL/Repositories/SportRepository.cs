using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;

namespace RoomBi.DAL.Repositories
{
    public class SportRepository: IRepositoryOfAll<Sport>,
        IRepositoryGetName<Sport>
    {
        private readonly RBContext context;

        public SportRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

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

        public async Task<Sport> GetByName(string name)
        {
            return await context.Sports.FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
