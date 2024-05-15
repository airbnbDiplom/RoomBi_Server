using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class OfferedAmenitiesRepository: 
        IRepositoryOfAll<OfferedAmenities>,
        IRepositoryGetName<OfferedAmenities>
    {
        private readonly RBContext context;
        public OfferedAmenitiesRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<OfferedAmenities>> GetAll()
        {
            return await context.OfferedAmenities.ToListAsync();
        }
        public async Task<OfferedAmenities> Get(int id)
        {

            return await context.OfferedAmenities.OrderByDescending(m => m.Id).FirstOrDefaultAsync();
        }
        public async Task Create(OfferedAmenities item)
        {
            await context.OfferedAmenities.AddAsync(item);
            await context.SaveChangesAsync();
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

        public async Task<OfferedAmenities> GetByName(string name)
        {
            return await context.OfferedAmenities.FirstOrDefaultAsync(m => m.Description == name);
        }

    }
}


