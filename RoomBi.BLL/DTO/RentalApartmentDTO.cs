using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RoomBi.DAL;
using RoomBi.DAL.Entities;

namespace RoomBi.BLL.DTO
{
    public class RentalApartmentDTO// для передачи одного элемента
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? IngMap { get; set; }
        public string? LatMap { get; set; }
        public int NumberOfGuests { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Beds { get; set; }
        public double PricePerNight { get; set; }
        public string? ObjectState { get; set; }
        public double ObjectRating { get; set; }
        public string? TypeApartment { get; set; }// Жилье целиком // Комната // Общая комната



        public string? Location { get; set; }
        public string? House { get; set; }
        public string? Sport { get; set; }
        public string? Country { get; set; }
        public OfferedAmenities? OfferedAmenities { get; set; }
        public string? MasterName { get; set; }
        public string? AirbnbRegistrationYear { get; set; }
        public string? MasterLanguage { get; set; }
        public string? Avatar { get; set; }
        public ICollection<BookingForApartmentPageDTO>? Booking { get; set; }
        public ICollection<GuestCommentsForRentalItemDTO>? GuestComments { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
    }
}
