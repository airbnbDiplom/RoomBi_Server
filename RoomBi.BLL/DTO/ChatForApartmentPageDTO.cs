using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class ChatForApartmentPageDTO
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int RentalApartmentId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
    }
    public class MessageStart
    {
       public ChatForApartmentPageDTO? ChatForApartmentPageDTO { get; set; }
       public BookingDTO? BookingDTO { get; set; }
    }
    public class BookingDTO
    {
        public int OwnerId { get; set; }
        public int ApartmentId { get; set; }
        public DateBi? CheckInDate { get; set; }
        public DateBi? CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public Payment? Payment { get; set; }

    }
    public class BookingDTOWithFoto
    {
        public int ApartmentId { get; set; }
        public string? TitleApartment { get; set; }
        public bool? Comment { get; set; } = false;
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public ICollection<Picture>? Pictures { get; set; }

    }
}
