namespace RoomBi.DAL
{
    public class EmergencyContactPerson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Сonnection { get; set; }
        public string? PhoneNumber { get; set; }



        public int CountryId { get; set; }
        public int IdUser { get; set; }
        public User? User { get; set; }

        public Country? Country { get; set; }
        

    }
}
