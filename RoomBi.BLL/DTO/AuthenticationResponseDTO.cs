using RoomBi.DAL;

namespace RoomBi.BLL.DTO
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Profile? Profile { get; set; }

    }
}
