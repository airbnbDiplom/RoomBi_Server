namespace RoomBi.DAL
{
    public class Profile
    {
        public int Id { get; set; }
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
        public int IdUser { get; set; }
        public User? User { get; set; }
    }
}
