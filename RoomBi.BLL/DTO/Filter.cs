using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
   public class Filter
    {
        public string? TypeAccommodation { get; set; }//Any,FullHouses,Room
        public string[]? TypeOfHousing { get; set; } //Тип житла (houses,Rooms,Countryhouses,Floatinghouses)
        public int? MinimumPrice { get; set; } //мінімальна ціна
        public int? MaximumPrice { get; set; } //максимальна ціна
        public int? Bedrooms { get; set; } //Спальні
        public int? Beds { get; set; } //Ліжка
        public int? Bathrooms { get; set; } //Ванні кімнати
        public bool Rating { get; set; } //рейтинг
        public string[]? OfferedAmenitiesDTO { get; set; } //OfferedAmenitiesDTO //Найнеобхідніше
        public string[]? HostsLanguage { get; set; } //Мова господаря
    }
}
