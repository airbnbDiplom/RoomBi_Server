using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RoomBi.DAL;
using RoomBi.DAL.Entities;
using RoomBi.BLL.DTO.New;

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
        public bool Wish { get; set; } = false;
        public OfferedAmenities? OfferedAmenities { get; set; }
        public MasterForApartmentPage? Master { get; set; }
        public ICollection<DateBooking>? DateBooking { get; set; }
        public ICollection<GuestСommentsDTO>? GuestComments { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
    }


    public class TransferDataDTO// для передачи одного элемента
    {
        public string? Title { get; set; }
        public string? Address { get; set; }
        public int MasterId { get; set; }
        public ICollection<Picture>? Pictures { get; set; }
        public string? IngMap { get; set; }
        public string? LatMap { get; set; }
        public int NumberOfGuests { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Beds { get; set; }
        public double PricePerNight { get; set; }
        public string? TypeApartment { get; set; }// Жилье целиком // Комната // Общая комната
        public string? Location { get; set; }
        public string? House { get; set; }
        public string? Sport { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public Int64 CityPlaceId { get; set; }
        public string? CountryCode { get; set; }
        public OfferedAmenities? OfferedAmenitiesDTO { get; set; }
    }
}
