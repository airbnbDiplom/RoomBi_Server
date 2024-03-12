namespace RoomBi.DAL
{
    public class Country
    {
        public Country()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
            this.Users = new HashSet<User>();
            this.EmergencyContactPersons = new HashSet<EmergencyContactPerson>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneCode { get; set; }
        public ICollection<RentalApartment> RentalApartments { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<EmergencyContactPerson> EmergencyContactPersons { get; set; }
    }
}
