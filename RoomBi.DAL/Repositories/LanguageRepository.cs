using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class LanguageRepository(RBContext context) : IRepositoryOfAll<Language>, IRepositoryGetName<Language>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<Language>> GetAll()
        {
            return await context.Languages.ToListAsync();
        }
        public async Task<Language> Get(int id)
        {

            return await context.Languages.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Languages.FindAsync(id);
        }
        public async Task<Language> GetByName(string name)
        {
            return await context.Languages.FirstOrDefaultAsync(c => c.Name == name);
        }
        public async Task Create(Language item)
        {
            await context.Languages.AddAsync(item);
        }
        public async Task Update(Language item)
        {
            context.Languages.Update(item);
        }
        public async Task Delete(int id)
        {
            Language? item = await context.Languages.FindAsync(id);
            if (item != null)
                context.Languages.Remove(item);
        }

      
    }
}
