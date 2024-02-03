using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class GuestСommentsService : IServiceOfAll<GuestCommentsDTO>
    {
        IUnitOfWork Database { get; set; }

        public GuestСommentsService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(GuestCommentsDTO guestСommentsDTO)
        {
            var guestСomments = new GuestComments
            {
                Id = guestСommentsDTO.Id,
                GuestIdUser = guestСommentsDTO.UserId,
                ApartmentId = guestСommentsDTO.ApartmentId,
                Comment = guestСommentsDTO.Comment,
                Rating = guestСommentsDTO.Rating
            };
            await Database.GuestComments.Create(guestСomments);
            await Database.Save();
        }

        public async Task Update(GuestCommentsDTO guestСommentsDTO)
        {
            var guestСomments = new GuestComments
            {
                Id = guestСommentsDTO.Id,
                GuestIdUser = guestСommentsDTO.UserId,
                ApartmentId = guestСommentsDTO.ApartmentId,
                Comment = guestСommentsDTO.Comment,
                Rating = guestСommentsDTO.Rating
            };
            await Database.GuestComments.Update(guestСomments);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.GuestComments.Delete(id);
            await Database.Save();
        }

        public async Task<GuestCommentsDTO> Get(int id)
        {
            var guestСomments = await Database.GuestComments.Get(id);
            if (guestСomments == null)
                throw new ValidationException("Wrong guestСomments!", "");
            return new GuestCommentsDTO
            {
                Id = guestСomments.Id,
                UserId = guestСomments.GuestIdUser,
                ApartmentId = guestСomments.ApartmentId,
                Comment = guestСomments.Comment,
                Rating = guestСomments.Rating
            };
        }

        public async Task<IEnumerable<GuestCommentsDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestComments, GuestCommentsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsDTO>>(await Database.GuestComments.GetAll());
        }

    }
}
