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
        public string? UserMaster { get; set; }
        public int GuestIdUser { get; set; }
        public string? UserGuest { get; set; }
    }
}
