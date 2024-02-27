
using RoomBi.DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomBi.BLL.DTO
{
    public class UserDTO
    {
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


        //public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        //public string? Hash { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }

    }
}
