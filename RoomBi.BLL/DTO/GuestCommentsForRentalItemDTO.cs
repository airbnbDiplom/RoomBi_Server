using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class GuestCommentsForRentalItemDTO
    {
        public int Id { get; set; }
        public int GuestIdUser { get; set; }
        public string? UserName { get; set; }
        public string? UserCountry { get; set; }
        public string? UserAvatar { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public double Rating { get; set; }
    }
}
