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
        public int MasterIdUser { get; set; }
        public int GuestIdUser { get; set; }
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
}
