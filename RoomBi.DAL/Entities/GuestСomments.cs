namespace RoomBi.DAL
{
    public class GuestСomments
    {
        public int Id { get; set; }
        public int GuestIdUser { get; set; }
        public int ApartmentId { get; set; }
        //public RentalApartment? RentalApartment { get; set; }
        public string? Comment { get; set; }
        public DateTime DateTime { get; set; }
        public double Rating { get; set; }
    }
}
