
namespace RoomBi.BLL.DTO
{
    public class Filter
    {
        public string? TypeAccommodation { get; set; } = "Будь-який";//Any,FullHouses,Room
        public string[]? TypeOfHousing { get; set; } //Тип житла (houses,Rooms,Countryhouses,Floatinghouses)
        public int? MinimumPrice { get; set; } = 0; //мінімальна ціна
        public int? MaximumPrice { get; set; } = 800; //максимальна ціна
        public int? Bedrooms { get; set; }  //Спальні
        public int? Beds { get; set; } //Ліжка
        public int? Bathrooms { get; set; } //Ванні кімнати
        public bool Rating { get; set; } = false; //рейтинг
        public string[]? OfferedAmenitiesDTO { get; set; } //OfferedAmenitiesDTO //Найнеобхідніше
        public string[]? HostsLanguage { get; set; } //Мова господаря
    }
}
