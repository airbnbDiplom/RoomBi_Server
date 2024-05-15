using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;

namespace RoomBi.DAL.Repositories
{
    public class HouseRepository: IRepositoryOfAll<House>, IRepositoryGetName<House>
    {
        private readonly RBContext context;

        public HouseRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<House>> GetAll()
        {
            return await context.Houses.ToListAsync();
        }
        public async Task<House> Get(int id)
        {

            return await context.Houses.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.PropertyTypes.FindAsync(id);
        }
        public async Task Create(House item)
        {
            await context.Houses.AddAsync(item);
        }
        public async Task Update(House item)
        {
            context.Houses.Update(item);
        }
        public async Task Delete(int id)
        {
            House? item = await context.Houses.FindAsync(id);
            if (item != null)
                context.Houses.Remove(item);
        }

        public async Task<House> GetByName(string name)
        {
            
            return await context.Houses.FirstOrDefaultAsync(m => m.Name == name);
        }
    }
}
