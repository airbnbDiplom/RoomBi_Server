using RoomBi.DAL;


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
        public Profile? Profile { get; set; }
        public bool CurrentStatus { get; set; }
        public bool UserStatus { get; set; }
        public string? RefreshToken { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? PF { get; set; } = "No";

    }
    public class UserDTOProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AirbnbRegistrationYear { get; set; }
        public string? ProfilePicture { get; set; }
        public bool CurrentStatus { get; set; }
        public bool UserStatus { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? PF { get; set; } = "No";
        public string? SchoolYears { get; set; } //Где прошли мои школьные годы,
        public string? Pets { get; set; } //Мои питомцы
        public string? Job { get; set; }//Моя работа
        public string? MyLocation { get; set; }// Где я живу
        public string? MyLanguages { get; set; } // Языки, на которых я говорю
        public string? Generation { get; set; }// Из какого я поколения
        public string? FavoriteSchoolSong { get; set; } // Любимая песня в школе
        public string? Passion { get; set; } // Что я безумно люблю
        public string? InterestingFact { get; set; }// Интересный факт обо мне
        public string? UselessSkill { get; set; }//Мой самый бесполезный навык
        public string? BiographyTitle { get; set; }//Так можно было бы назвать мою биографию
        public string? DailyActivity { get; set; }//Что я делаю часами  
        public string? AboutMe { get; set; }// Oбо мне
        public ICollection<CommentsAboutGuestDTO>? CommentsAboutGuestDTO { get; set; }
        public ICollection<RentalApartmentDTOForStartPage>? RentalApartments { get; set; }
        public ICollection<BookingDTOWithFoto>? BookingDTOWithFoto { get; set; }
    }
}
