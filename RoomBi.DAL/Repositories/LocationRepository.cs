using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;


namespace RoomBi.DAL.Repositories
{
    public class LocationRepository(RBContext context) : IRepositoryOfAll<Location>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<Location>> GetAll()
        {
            return await context.Locations.ToListAsync();
        }
        public async Task<Location> Get(int id)
        {

            return await context.Locations.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.PropertyTypes.FindAsync(id);
        }
        public async Task Create(Location item)
        {
            await context.Locations.AddAsync(item);
        }
        public async Task Update(Location item)
        {
            context.Locations.Update(item);
        }
        public async Task Delete(int id)
        {
            Location? item = await context.Locations.FindAsync(id);
            if (item != null)
                context.Locations.Remove(item);
        }
    }
}
