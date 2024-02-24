using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class MasterForApartmentPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; } // Дата рождения
        public int? HostingGuests { get; set; } // Сколько лет принимает гостей
        public string JoiningTheCommunity { get; set; } // Дата вступления в сообщество
        public string ProfilePicture { get; set; } // Аватар профиля
        public bool CurrentStatus { get; set; } // Текущий статус
        public string Language { get; set; } // Язык
        public string Country { get; set; } // Страна
    }
}
