

namespace RoomBi.DAL
{
    public class Chat
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public int RentalApartmentId { get; set; }
        public int From { get; set; }
        //public User? UserMaster { get; set; }
        public int To { get; set; }
        //public User? UserGuest { get; set; }
    }
}
