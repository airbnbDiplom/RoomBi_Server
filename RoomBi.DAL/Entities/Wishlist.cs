namespace RoomBi.DAL
{
    public class Wishlist
    {
        public Wishlist()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public ICollection<RentalApartment> RentalApartments { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ApartmentId { get; set; }
    }
}
