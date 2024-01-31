using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class GuestPaymentMethodDTO
    {
        public int Id { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? CVV { get; set; }
        public string? CardType { get; set; }
        public int IdUser { get; set; }
       // public User? User { get; set; }
    }
}
