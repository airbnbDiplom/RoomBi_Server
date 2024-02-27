using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class GuestPaymentMethodService(IUnitOfWork uow) : IServiceOfAll<Payment>
    {
        IUnitOfWork Database { get; set; } = uow;

        public async Task Create(Payment guestPaymentMethodDTO)
        {
            var guestPaymentMethod = new GuestPaymentMethod
            {
                //Id = guestPaymentMethodDTO.Id,
                CardNumber = guestPaymentMethodDTO.CardNumber,
                ExpirationDate = guestPaymentMethodDTO.ExpirationDate,
                CVV = guestPaymentMethodDTO.CVV,
                CardType = guestPaymentMethodDTO.CardType,
                //IdUser = guestPaymentMethodDTO.IdUser
            };
            await Database.GuestPaymentMethod.Create(guestPaymentMethod);
            await Database.Save();
        }

        public async Task Update(Payment guestPaymentMethodDTO)
        {
            var guestPaymentMethod = new GuestPaymentMethod
            {
                //Id = guestPaymentMethodDTO.Id,
                CardNumber = guestPaymentMethodDTO.CardNumber,
                ExpirationDate = guestPaymentMethodDTO.ExpirationDate,
                CVV = guestPaymentMethodDTO.CVV,
                CardType = guestPaymentMethodDTO.CardType,
                //IdUser = guestPaymentMethodDTO.IdUser
            };
            await Database.GuestPaymentMethod.Update(guestPaymentMethod);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.GuestPaymentMethod.Delete(id);
            await Database.Save();
        }

        public async Task<Payment> Get(int id)
        {
            var guestPaymentMethod = await Database.GuestPaymentMethod.Get(id);
            if (guestPaymentMethod == null)
                throw new ValidationException("Wrong guestPaymentMethod!", "");
            return new Payment
            {
                //Id = guestPaymentMethod.Id,
                CardNumber = guestPaymentMethod.CardNumber,
                ExpirationDate = guestPaymentMethod.ExpirationDate,
                CVV = guestPaymentMethod.CVV,
                CardType = guestPaymentMethod.CardType,
                //IdUser = guestPaymentMethod.IdUser
            };
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestPaymentMethod, Payment>()).CreateMapper();
            return mapper.Map<IEnumerable<GuestPaymentMethod>, IEnumerable<Payment>>(await Database.GuestPaymentMethod.GetAll());
        }

    }
}
