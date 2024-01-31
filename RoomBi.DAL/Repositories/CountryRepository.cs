using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class CountryRepository : IRepositoryOfAll<Country>
    {
        private readonly RBContext context;
        public CountryRepository(RBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await context.Countries.ToListAsync();
        }
        public async Task<Country> Get(int id)
        {

            return await context.Countries.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Countrys.FindAsync(id);
        }
        public async Task Create(Country item)
        {
            await context.Countries.AddAsync(item);
        }
        public async Task Update(Country item)
        {
            context.Countries.Update(item);
        }
        public async Task Delete(int id)
        {
            Country? item = await context.Countries.FindAsync(id);
            if (item != null)
                context.Countries.Remove(item);
        }
    }
}
