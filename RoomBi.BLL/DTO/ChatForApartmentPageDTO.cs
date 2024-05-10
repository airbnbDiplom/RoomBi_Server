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
   
}
