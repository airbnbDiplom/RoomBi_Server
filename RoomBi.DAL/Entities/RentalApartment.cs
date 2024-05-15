using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RoomBi.DAL.Entities;

namespace RoomBi.DAL
{
    public class RentalApartment
    {
        public RentalApartment()
        {
            this.Booking = new HashSet<Booking>();
            this.GuestComments = new HashSet<GuestComments>();
            this.Pictures = new HashSet<Picture>();
            this.Chats = new HashSet<Chat>();

        }

        public ICollection<Booking> Booking { get; set; }
        public ICollection<GuestComments> GuestComments { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Chat> Chats { get; set; }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public Int64 PlaceId { get; set; }
        public string? CountryCode { get; set; }
        public string? IngMap { get; set; }
        public string? LatMap { get; set; }
        public int NumberOfGuests { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Beds { get; set; }
        public double PricePerNight { get; set; }
        public string? ObjectState { get; set; } = "Вільний";
        public double ObjectRating { get; set; }

        public int OfferedAmenitiesId { get; set; } = 1;
        public OfferedAmenities? OfferedAmenities { get; set; }

        public string TypeApartment { get; set; }// Жилье целиком // Комната // Общая комната
        public int LocationId { get; set; } = 1;
        public Location? Location { get; set; }
        public int HouseId { get; set; } = 1;
        public House? House { get; set; }
        public int SportId { get; set; } = 1;
        public Sport? Sport { get; set; }
        public int CountryId { get; set; } = 1;
        public Country? Country { get; set; }/// <summary>
        /// 
        /// </summary>
        //public int СontinentId { get; set; }
        //public Сontinent? Сontinent { get; set; }
        public int UserId { get; set; } = 1;
        public User? User { get; set; }

    }
}
