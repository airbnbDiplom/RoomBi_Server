using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class PictureRepository(RBContext context) : IRepositoryOfAll<Picture>, IRepositoryGetAllByID<Picture>
    {
        private readonly RBContext context = context;
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
            await context.Pictures.AddAsync(item);
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

