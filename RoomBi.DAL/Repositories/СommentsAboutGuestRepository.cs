﻿using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class CommentsAboutGuestRepository(RBContext context) : IRepositoryOfAll<CommentsAboutGuest>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<CommentsAboutGuest>> GetAll()
        {
            return await context.CommentsAboutGuests.ToListAsync();
        }
        public async Task<CommentsAboutGuest> Get(int id)
        {

              return await context.CommentsAboutGuests.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.CommentsAboutGuests.FindAsync(id);
        } 
        public async Task Create(CommentsAboutGuest item)
        {
            await context.CommentsAboutGuests.AddAsync(item);
        }
        public async Task Update(CommentsAboutGuest item)
        {
            context.CommentsAboutGuests.Update(item);
        }
        public async Task Delete(int id)
        {
            CommentsAboutGuest? item = await context.CommentsAboutGuests.FindAsync(id);
            if (item != null)
                context.CommentsAboutGuests.Remove(item);
        }
    }
}

