using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class OfferedAmenitiesRepository(RBContext context) : IRepositoryOfAll<OfferedAmenities>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<OfferedAmenities>> GetAll()
        {
            return await context.OfferedAmenities.ToListAsync();
        }
        public async Task<OfferedAmenities> Get(int id)
        {

            return await context.OfferedAmenities.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.OfferedAmenities.FindAsync(id);
        }
        public async Task Create(OfferedAmenities item)
        {
            await context.OfferedAmenities.AddAsync(item);
        }
        public async Task Update(OfferedAmenities item)
        {
            context.OfferedAmenities.Update(item);
        }
        public async Task Delete(int id)
        {
            OfferedAmenities? item = await context.OfferedAmenities.FindAsync(id);
            if (item != null)
                context.OfferedAmenities.Remove(item);
        }
    }
}


