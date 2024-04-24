using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class MessageObj
    {
        public string? FotoFrom { get; set; }
        public string? FotoTo { get; set; }
        public string? FotoApartment { get; set; }
        public string? NameApartment { get; set; }
        public string? NameFrom { get; set; }
        public string? NameTo { get; set; }
        public Booking? Booking { get; set; }
        public List<ChatForApartmentPageDTO>? Message { get; set; }
    }
}
