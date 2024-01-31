namespace RoomBi.DAL
{
    public class Picture
    {
        public int Id { get; set; }
        public string? PictureName { get; set; }
        public string? PictureUrl { get; set; }
        public int RentalApartmentId { get; set; }
    }
}
