using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class HouseDTO
    {
        public HouseDTO()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // Дом// Квартира // Автодом // Замок// Пещера// Контейнер// Купольный дом// Земляной дом // Ферма // Гостевой дом // Гостиница // Плавучий дом // Микродом // Мельница// Дом на дереве // Юрта // Башня// Кикладский дом // Амбар// B&B // Лодка

        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
