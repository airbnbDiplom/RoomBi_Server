using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class GuestCommentsForRentalItemDTO
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
