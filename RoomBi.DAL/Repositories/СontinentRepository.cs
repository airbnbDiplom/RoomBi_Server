using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class СontinentRepository : IRepositoryOfAll<Сontinent>, IRepositoryGetName<Сontinent>
    {
        private readonly RBContext context;
        public СontinentRepository(RBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Сontinent>> GetAll()
        {
            return await context.Сontinent.ToListAsync();
        }
        public async Task<Сontinent> Get(int id)
        {

            return await context.Сontinent.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Countrys.FindAsync(id);
        }
        public async Task<Сontinent> GetByName(string name)
        {
            return await context.Сontinent.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task Create(Сontinent item)
        {
            await context.Сontinent.AddAsync(item);
        }
        public async Task Update(Сontinent item)
        {
            context.Сontinent.Update(item);
        }
        public async Task Delete(int id)
        {
            Сontinent? item = await context.Сontinent.FindAsync(id);
            if (item != null)
                context.Сontinent.Remove(item);
        }
    }
}
