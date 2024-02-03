using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class GuestCommentsDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
       // public RentalApartment? RentalApartment { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public double Rating { get; set; }
    }
}
