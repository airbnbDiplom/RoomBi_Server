using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class GuestСommentsService : IServiceOfAll<GuestСommentsDTO>
    {
        IUnitOfWork Database { get; set; }

        public GuestСommentsService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(GuestСommentsDTO guestСommentsDTO)
        {
            var guestСomments = new GuestСomments
            {
                Id = guestСommentsDTO.Id,
                GuestIdUser = guestСommentsDTO.UserId,
                ApartmentId = guestСommentsDTO.ApartmentId,
                Comment = guestСommentsDTO.Comment,
                Rating = guestСommentsDTO.Rating
            };
            await Database.GuestСomments.Create(guestСomments);
            await Database.Save();
        }

        public async Task Update(GuestСommentsDTO guestСommentsDTO)
        {
            var guestСomments = new GuestСomments
            {
                Id = guestСommentsDTO.Id,
                GuestIdUser = guestСommentsDTO.UserId,
                ApartmentId = guestСommentsDTO.ApartmentId,
                Comment = guestСommentsDTO.Comment,
                Rating = guestСommentsDTO.Rating
            };
            await Database.GuestСomments.Update(guestСomments);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.GuestСomments.Delete(id);
            await Database.Save();
        }

        public async Task<GuestСommentsDTO> Get(int id)
        {
            var guestСomments = await Database.GuestСomments.Get(id);
            if (guestСomments == null)
                throw new ValidationException("Wrong guestСomments!", "");
            return new GuestСommentsDTO
            {
                Id = guestСomments.Id,
                UserId = guestСomments.GuestIdUser,
                ApartmentId = guestСomments.ApartmentId,
                Comment = guestСomments.Comment,
                Rating = guestСomments.Rating
            };
        }

        public async Task<IEnumerable<GuestСommentsDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestСomments, GuestСommentsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GuestСomments>, IEnumerable<GuestСommentsDTO>>(await Database.GuestСomments.GetAll());
        }

    }
}
