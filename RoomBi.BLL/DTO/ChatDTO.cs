

namespace RoomBi.BLL.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int RentalApartmentId { get; set; }
        public int MasterIdUser { get; set; }
        //public User? UserMaster { get; set; }
        public int GuestIdUser { get; set; }
        //public User? UserGuest { get; set; }
    }
}
