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
        public string? FotoMaster { get; set; }
        public string? FotoApartment { get; set; }
        public string? NameApartment { get; set; }
        public string? NameMaster { get; set; }
        public Booking? Booking { get; set; }
        public List<ChatForApartmentPageDTO>? Message { get; set; }
    }
}
