
using RoomBi.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBi.BLL.DTO
{
    public class UserDTO
    {
        //public ICollection<Booking>? Booking { get; set; }// этому не надо
        //public ICollection<GuestComments>? GuestComments { get; set; }
        //public ICollection<Picture>? Pictures { get; set; }
        //public ICollection<Chat>? Chats { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AirbnbRegistrationYear { get; set; }
        public string? ProfilePicture { get; set; }
       
        public bool CurrentStatus { get; set; } //bool
        public bool UserStatus { get; set; }//bool


        public int LanguageId { get; set; }
        public int CountryId { get; set; }
       // public Country? Country { get; set; }
       // public Language? Language { get; set; }
       
    }
}
