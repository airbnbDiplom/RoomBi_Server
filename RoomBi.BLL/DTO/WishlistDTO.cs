using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class WishlistDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public User? User { get; set; }
        public int ApartmentId { get; set; }
    }
}
