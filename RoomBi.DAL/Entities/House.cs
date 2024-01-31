namespace RoomBi.DAL
{
    public class House 
    {
        public House()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // Дом// Квартира // Автодом // Замок// Пещера// Контейнер// Купольный дом// Земляной дом // Ферма // Гостевой дом // Гостиница // Плавучий дом // Микродом // Мельница// Дом на дереве // Юрта // Башня// Кикладский дом // Амбар// B&B // Лодка

        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
