﻿using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class ChatRepository : IRepositoryOfAll<Chat>, IRepositoryGetAllByID<Chat>,
         IRepositoryForChat<Chat>
    {
        private readonly RBContext context;

        public ChatRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Chat>> GetAllById(int apartmentId)// коллекция для определенной квартиры
        {
            return await context.Chats
               .Where(chat => chat.RentalApartmentId == apartmentId)
               .ToListAsync();
        }
        public async Task<IEnumerable<Chat>> GetAll()
        {
            var chatMessages = await context.Chats.ToListAsync();
            Console.WriteLine($"Retrieved {chatMessages.Count} chat messages");
            return chatMessages;
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

        public async Task<List<List<Chat>>> GetAllChat(int user)
        {
            var chatMessages = await context.Chats
            .Where(chat => (chat.To == user || chat.From == user))
            .ToListAsync();

            var groupedMessages = chatMessages
                .GroupBy(m => m.RentalApartmentId)
                .Select(g => g.ToList())
                .ToList();

            return groupedMessages;
        }
    }
}
