using System.Text.Json.Serialization;

namespace RoomBi.DAL
{
    public class Booking
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User? User { get; set; }
        public int ApartmentId { get; set; }
        [JsonIgnore]
        public RentalApartment? RentalApartment { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public double TotalPrice { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
