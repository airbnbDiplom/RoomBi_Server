using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class ChatRepository(RBContext context) : IRepositoryOfAll<Chat>, IRepositoryForApartment<Chat>
    {
        private readonly RBContext context = context;
        public async Task<IEnumerable<Chat>> ByApartmentId(int apartmentId)// коллекция для определенной квартиры
        {
                 return await context.Chats
                    .Where(chat => chat.RentalApartmentId == apartmentId)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Chat>> GetAll()
        {
            return await context.Chats.ToListAsync();
        }
        public async Task<Chat> Get(int id)
        {

            return await context.Chats.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Chats.FindAsync(id);
        }
        public async Task Create(Chat item)
        {
            await context.Chats.AddAsync(item);
        }
        public async Task Update(Chat item)
        {
            context.Chats.Update(item);
        }
        public async Task Delete(int id)
        {
            Chat? item = await context.Chats.FindAsync(id);
            if (item != null)
                context.Chats.Remove(item);
        }
    }
}
