

using System.Globalization;

namespace RoomBi.DAL
{
    public class User
    {
        public User()
        {
            this.CommentsAboutGuests = new HashSet<CommentsAboutGuest>();
            this.Chat = new HashSet<Chat>();
            this.GuestСomments = new HashSet<GuestComments>();
            this.Users = new HashSet<User>();
        }
        public ICollection<CommentsAboutGuest> CommentsAboutGuests { get; set; }
        public ICollection<Chat> Chat { get; set; }
        public ICollection<GuestComments> GuestСomments { get; set; }
        public ICollection<User> Users { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AirbnbRegistrationYear { get; set; }
        public string? ProfilePicture { get; set; }
        public string? RefreshToken { get; set; }
        public string? Hash { get; set; }
        public bool CurrentStatus { get; set; } //bool
        public bool UserStatus { get; set; }//bool
        public int LanguageId { get; set; } = 1;
        public int CountryId { get; set; } = 1;
        public string? Salt { get; set; }

        public bool IsGoogleServiceUsed { get; set; }
        public Country? Country { get; set; }
        public Language? Language { get; set; }
       
    }
}
