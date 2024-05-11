using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class CountryRepository : IRepositoryOfAll<Country>, IRepositoryGetName<Country>
    {
        private readonly RBContext context;

        public CountryRepository(RBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Country>> GetAll()
        {

            return await context.Countries.ToListAsync();

        }

        public async Task<Country> Get(int id)
        {
            return await context.Countries.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Country> GetByName(string name)
        {
            return await context.Countries.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task Create(Country item)
        {
            await context.Countries.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Country item)
        {
            context.Countries.Update(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Country item = await context.Countries.FindAsync(id);
            if (item != null)
            {
                context.Countries.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }

}
