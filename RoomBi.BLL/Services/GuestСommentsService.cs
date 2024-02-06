using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class GuestСommentsService(IUnitOfWork uow) : IServiceOfAll<GuestCommentsForRentalItemDTO>, IServiseForComments<GuestCommentsForRentalItemDTO>
    {
        public async Task<IEnumerable<GuestCommentsForRentalItemDTO>> GetAllForRentalItem(int?  apartmentId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestComments, GuestCommentsForRentalItemDTO>()).CreateMapper();

            var allGuestComments = await Database.GuestComments.GetAll();

            if (apartmentId.HasValue)
            {
                var filteredComments = allGuestComments
                    .Where(comment => comment.ApartmentId == apartmentId.Value)
                    .ToList();

                return mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsForRentalItemDTO>>(filteredComments);
            }
            var guestCommentsForRentalItemDTO = mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsForRentalItemDTO>>(allGuestComments);
            return mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsForRentalItemDTO>>(allGuestComments);
        }
        public async Task<IEnumerable<GuestCommentsForRentalItemDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuestComments, GuestCommentsForRentalItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsForRentalItemDTO>>(await Database.GuestComments.GetAll());
        }
        IUnitOfWork Database { get; set; } = uow;

        public async Task Create(GuestCommentsForRentalItemDTO guestСommentsDTO)
        {
            var guestСomments = new GuestComments
            {
                Id = guestСommentsDTO.Id,
                //GuestIdUser = guestСommentsDTO.UserId,
                //ApartmentId = guestСommentsDTO.ApartmentId,
                Comment = guestСommentsDTO.Comment,
                Rating = guestСommentsDTO.Rating
            };
            await Database.GuestComments.Create(guestСomments);
            await Database.Save();
        }

        public async Task Update(GuestCommentsForRentalItemDTO guestСommentsDTO)
        {
            var guestСomments = new GuestComments
            {
                Id = guestСommentsDTO.Id,
                //GuestIdUser = guestСommentsDTO.UserId,
                //ApartmentId = guestСommentsDTO.ApartmentId,
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

        public async Task<GuestCommentsForRentalItemDTO> Get(int id)
        {
            var guestСomments = await Database.GuestComments.Get(id);
            if (guestСomments == null)
                throw new ValidationException("Wrong guestСomments!", "");
            return new GuestCommentsForRentalItemDTO
            {
                Id = guestСomments.Id,
                //UserId = guestСomments.GuestIdUser,
                //ApartmentId = guestСomments.ApartmentId,
                Comment = guestСomments.Comment,
                Rating = guestСomments.Rating
            };
        }

       
    }
}
