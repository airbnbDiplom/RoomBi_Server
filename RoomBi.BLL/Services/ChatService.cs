using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO.New;
using RoomBi.BLL.DTO;
using System.Net.Http;
using System.Security.Claims;
using System.Collections.Generic;

namespace RoomBi.BLL.Services
{

    public class ChatService : IServiceChat<ChatForApartmentPageDTO>
    {
        IUnitOfWork Database { get; set; }

        public ChatService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(ChatForApartmentPageDTO chatDto)
        {

            var chat = new Chat
            {
                Id = chatDto.Id,
                Comment = chatDto.Comment,
                DateTime = chatDto.DateTime,
                RentalApartmentId = chatDto.RentalApartmentId,
                MasterIdUser = chatDto.MasterIdUser,
                GuestIdUser = chatDto.GuestIdUser

            };
            await Database.Chat.Create(chat);
            await Database.Save();
        }

     

        //public async Task Update(ChatDTO chatDto)
        //{
        //    var chat = new Chat
        //    {
        //        Id = chatDto.Id,
        //        Comment = chatDto.Comment,
        //        DateTime = chatDto.DateTime,
        //        RentalApartmentId = chatDto.RentalApartmentId,
        //        MasterIdUser = chatDto.MasterIdUser,
        //        GuestIdUser = chatDto.GuestIdUser

        //    };
        //    await Database.Chat.Update(chat);
        //    await Database.Save();
        //}

        //public async Task Delete(int id)
        //{
        //    await Database.Chat.Delete(id);
        //    await Database.Save();
        //}

        //public async Task<ChatDTO> Get(int id)
        //{
        //    var chat = await Database.Chat.Get(id);
        //    if (chat == null)
        //        throw new ValidationException("Wrong chat!", "");
        //    return new ChatDTO
        //    {
        //        Id = chat.Id,
        //        Comment = chat.Comment,
        //        DateTime = chat.DateTime,
        //        RentalApartmentId = chat.RentalApartmentId,
        //        MasterIdUser = chat.MasterIdUser,
        //        GuestIdUser = chat.GuestIdUser
        //    };
        //}

        //public async Task<IEnumerable<ChatDTO>> GetAll()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chat, ChatDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Chat>, IEnumerable<ChatDTO>>(await Database.Chat.GetAll());
        //}

    }
}
