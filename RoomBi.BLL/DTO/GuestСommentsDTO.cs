using RoomBi.DAL;

namespace RoomBi.BLL.DTO.New
{
    public class GuestСommentsDTO
    {
        public int Id { get; set; }
        public int GuestIdUser { get; set; }
        public string? UserName { get; set; } // Имя пользователя
        public string? UserCountry { get; set; } // Страна пользователя
        public string? UserAvatar { get; set; } // Аватар пользователя
        public string? Comment { get; set; } // Текст комментария
        public DateTime DateTime { get; set; } // Дата и время комментария
        public double Rating { get; set; } // Рейтинг
    }
}
