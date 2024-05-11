using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;


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
                From = chatDto.FromId,
                To = chatDto.ToId

            };
            await Database.Chat.Create(chat);
            await Database.Save();
        }
    }
}
