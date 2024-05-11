using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;

namespace RoomBi.DAL.Repositories
{
    public class GuestPaymentMethodRepository : IRepositoryOfAll<GuestPaymentMethod>
    {
        private readonly RBContext context;
        public GuestPaymentMethodRepository(RBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<GuestPaymentMethod>> GetAll()
        {
            return await context.GuestPaymentMethods.ToListAsync();
        }
        public async Task<GuestPaymentMethod> Get(int id)
        {

            return await context.GuestPaymentMethods.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.GuestPaymentMethods.FindAsync(id);
        }
        public async Task Create(GuestPaymentMethod item)
        {
            var temp = await context.GuestPaymentMethods.FirstOrDefaultAsync(m => m.CardNumber == item.CardNumber);
            if(temp != null)
            {
                return;
            }
            await context.GuestPaymentMethods.AddAsync(item);
        }
        public async Task Update(GuestPaymentMethod item)
        {
            context.GuestPaymentMethods.Update(item);
        }
        public async Task Delete(int id)
        {
            GuestPaymentMethod? item = await context.GuestPaymentMethods.FindAsync(id);
            if (item != null)
                context.GuestPaymentMethods.Remove(item);
        }
    }
}
