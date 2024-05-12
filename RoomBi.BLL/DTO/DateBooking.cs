using RoomBi.BLL.DTO;
using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class DateBi
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateBi(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }
        public DateBi()
        {
        }
    }
    public class DateBookingAlex
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class DateBooking
    {
        public DateBi? Start { get; set; }
        public DateBi? End { get; set; }

        public DateBooking(DateTime start, DateTime end)
        {
            Start = new DateBi(start);
            End = new DateBi(end);
        }
        public DateBooking()
        {
        }

    }

}
public class BookingDTO
{
    public int OwnerId { get; set; }
    public int ApartmentId { get; set; }
    public DateBi? CheckInDate { get; set; }
    public DateBi? CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
    public Payment? Payment { get; set; }

}
public class BookingDTOWithFoto
{
    public int ApartmentId { get; set; }
    public string? TitleApartment { get; set; }
    public string? CountryApartment { get; set; }
    public bool? Comment { get; set; } = false;
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public double TotalPrice { get; set; }
    public ICollection<Picture>? Pictures { get; set; }
}
