using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class PictureRepository : IRepositoryOfAll<Picture>, IRepositoryGetAllByID<Picture>
    {
        private readonly RBContext context;
        public PictureRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Picture>> GetAllById(int apartmentId)// коллекция для определенной квартиры
        {
            return await context.Pictures
                .Where(picture => picture.RentalApartmentId == apartmentId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Picture>> GetAll()
        {
            return await context.Pictures.ToListAsync();
        }
        public async Task<Picture> Get(int id)
        {

            return await context.Pictures.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Pictures.FindAsync(id);
        }
        public async Task Create(Picture item)
        {
            await context.Pictures.AddAsync(item); await context.SaveChangesAsync();
        }
        public async Task Update(Picture item)
        {
            context.Pictures.Update(item);
        }
        public async Task Delete(int id)
        {
            Picture? item = await context.Pictures.FindAsync(id);
            if (item != null)
                context.Pictures.Remove(item);
        }
    }
}

