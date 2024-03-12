using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class WishlistService(IUnitOfWork uow) : IServiceOfAll<WishlistDTO>
    {
        IUnitOfWork Database { get; set; } = uow;

        public async Task Create(WishlistDTO wishlistDTO)
        {
            if (!await Database.GetItemWishlist.CheckIfWishlistItemExists(wishlistDTO.UserId, wishlistDTO.ApartmentId))
            {
                var wishlist = new Wishlist
                {
                    Id = wishlistDTO.Id,
                    UserId = wishlistDTO.UserId,
                    ApartmentId = wishlistDTO.ApartmentId
                };
                await Database.Wishlist.Create(wishlist); 
                await Database.Save();
                throw new Exception("Ok");

            }
            else
            {
                await Database.GetItemWishlist.DeleteIfWishlistItem(wishlistDTO.UserId, wishlistDTO.ApartmentId);
                await Database.Save();
                throw new Exception("No");
            }
        }

        public async Task Update(WishlistDTO wishlistDTO)
        {
            var wishlist = new Wishlist
            {
                Id = wishlistDTO.Id,
                UserId = wishlistDTO.UserId,
                ApartmentId = wishlistDTO.ApartmentId
            };
            await Database.Wishlist.Update(wishlist);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Wishlist.Delete(id);
            await Database.Save();
        }

        public async Task<WishlistDTO> Get(int id)
        {
            var wishlist = await Database.Wishlist.Get(id);
            if (wishlist == null)
                throw new ValidationException("Wrong wishlist!", "");
            return new WishlistDTO
            {
                Id = wishlist.Id,
                UserId = wishlist.UserId,
                ApartmentId = wishlist.ApartmentId
            };
        }

        public async Task<IEnumerable<WishlistDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Wishlist, WishlistDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Wishlist>, IEnumerable<WishlistDTO>>(await Database.Wishlist.GetAll());
        }

    }
}
