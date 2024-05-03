using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class CommentsAboutGuestService : IServiceOfAll<CommentsAboutGuestDTO>
    {
        IUnitOfWork Database { get; set; }

        public CommentsAboutGuestService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(CommentsAboutGuestDTO commentsAboutGuestDTO)
        {
            var commentsAboutGuest = new CommentsAboutGuest
            {
                Id = commentsAboutGuestDTO.Id,
                Comment = commentsAboutGuestDTO.Comment,
                DateComments = commentsAboutGuestDTO.DateComments,
                MasterIdUser = commentsAboutGuestDTO.MasterId
              
            };
            await Database.CommentsAboutGuest.Create(commentsAboutGuest);
            await Database.Save();
        }

        public async Task Update(CommentsAboutGuestDTO commentsAboutGuestDTO)
        {
            var commentsAboutGuest = new CommentsAboutGuest
            {
                Id = commentsAboutGuestDTO.Id,
                Comment = commentsAboutGuestDTO.Comment,
                DateComments = commentsAboutGuestDTO.DateComments,
                MasterIdUser = commentsAboutGuestDTO.MasterId
                
            };
            await Database.CommentsAboutGuest.Update(commentsAboutGuest);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.CommentsAboutGuest.Delete(id);
            await Database.Save();
        }

        public async Task<CommentsAboutGuestDTO> Get(int id)
        {
            var commentsAboutGuest = await Database.CommentsAboutGuest.Get(id);
            if (commentsAboutGuest == null)
                throw new ValidationException("Wrong commentsAboutGuest!", "");
            return new CommentsAboutGuestDTO
            {
                Id = commentsAboutGuest.Id,
                Comment = commentsAboutGuest.Comment,
                DateComments = commentsAboutGuest.DateComments,
                MasterId = commentsAboutGuest.MasterIdUser,
               
            };
        }

        public async Task<IEnumerable<CommentsAboutGuestDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentsAboutGuest, CommentsAboutGuestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CommentsAboutGuest>, IEnumerable<CommentsAboutGuestDTO>>(await Database.CommentsAboutGuest.GetAll());
        }

    }
}
