using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class GuestPaymentMethodService : IServiceOfAll<GuestPaymentMethodDTO>
    {
        IUnitOfWork Database { get; set; }

        public GuestPaymentMethodService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(GuestPaymentMethodDTO guestPaymentMethodDTO)
        {
            var guestPaymentMethod = new GuestPaymentMethod
            {
                Id = guestPaymentMethodDTO.Id,
                CardNumber = guestPaymentMethodDTO.CardNumber,
                ExpirationDate = guestPaymentMethodDTO.ExpirationDate,
                CVV = guestPaymentMethodDTO.CVV,
                CardType = guestPaymentMethodDTO.CardType,
                IdUser = guestPaymentMethodDTO.IdUser
            };
            await Database.GuestPaymentMethod.Create(guestPaymentMethod);
            await Database.Save();
        }

        public async Task Update(GuestPaymentMethodDTO guestPaymentMethodDTO)
        {
            var guestPaymentMethod = new GuestPaymentMethod
            {
                Id = guestPaymentMethodDTO.Id,
                CardNumber = guestPaymentMethodDTO.CardNumber,
                ExpirationDate = guestPaymentMethodDTO.ExpirationDate,
                CVV = guestPaymentMethodDTO.CVV,
                CardType = guestPaymentMethodDTO.CardType,
                IdUser = guestPaymentMethodDTO.IdUser
            };
            await Database.GuestPaymentMethod.Update(guestPaymentMethod);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.GuestPaymentMethod.Delete(id);
            await Database.Save();
        }

        public async Task<GuestPaymentMethodDTO> Get(int id)
        {
            var guestPaymentMethod = await Database.GuestPaymentMethod.Get(id);
            if (guestPaymentMethod == null)
                throw new ValidationException("Wrong guestPaymentMethod!", "");
            return new GuestPaymentMethodDTO
            {
                Id = guestPaymentMethod.Id,
                CardNumber = guestPaymentMethod.CardNumber,
                ExpirationDate = guestPaymentMethod.ExpirationDate,
                CVV = guestPaymentMethod.CVV,
                CardType = guestPaymentMethod.CardType,
                IdUser = guestPaymentMethod.IdUser
            };
        }

        public async Task<IEnumerable<GuestPaymentMethodDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestPaymentMethod, GuestPaymentMethodDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GuestPaymentMethod>, IEnumerable<GuestPaymentMethodDTO>>(await Database.GuestPaymentMethod.GetAll());
        }

    }
}
