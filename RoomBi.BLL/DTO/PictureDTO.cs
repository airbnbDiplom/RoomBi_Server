using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string? PictureName { get; set; }
        public string? PictureUrl { get; set; }
        public int RentalApartmentId { get; set; }
    }
}
