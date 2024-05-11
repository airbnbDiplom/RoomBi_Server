

namespace RoomBi.BLL.DTO
{
    public class DataSearchForSorting
    {
        public Where? Where { get; set; }
        public DateBookingAlex? When { get; set; }
        public int Why { get; set; }
    }
    public class Where
    {
        public string? Type { get; set; }
        public string? CountryCode { get; set; }
        public int? PlaceId { get; set; }
    }

}
