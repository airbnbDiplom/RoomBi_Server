using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class WishlistRepository(RBContext context) : IRepositoryOfAll<Wishlist>, IRepositoryGetWishlictitem<Wishlist>
    {
        private readonly RBContext context = context;

        public async Task<IEnumerable<Wishlist>> GetAll()
        {
            return await context.Wishlists.ToListAsync();
        }
        public async Task<Wishlist> Get(int id)
        {

            return await context.Wishlists.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.Wishlists.FindAsync(id);
        }
        public async Task Create(Wishlist item)
        {
            await context.Wishlists.AddAsync(item);
        }
        public async Task Update(Wishlist item)
        {
            context.Wishlists.Update(item);
        }
        public async Task Delete(int id)
        {
            Wishlist? item = await context.Wishlists.FindAsync(id);
            if (item != null)
                context.Wishlists.Remove(item);
        }

        

        public async Task<Boolean> CheckIfWishlistItemExists(int userId, int apartId)
        {
            try
            {
                var wishlistItems = await context.Wishlists
                    .Where(w => w.UserId == userId && w.ApartmentId == apartId)
                    .ToListAsync();
                return wishlistItems.Count != 0;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    }
}

