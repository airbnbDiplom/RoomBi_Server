
using RoomBi.BLL.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace RoomBi_Server.Token
{
    public interface IJwtToken
    {
        // Створення JWT
        public string GetToken(UserDTO user);

        //оновлення токену  
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string? token);
        public UserDTO GetUserInfoFromToken(string? token);

        //отримати пошту з токену
        public string GetMailFromToken(ClaimsPrincipal principal);
        public string GetIdFromToken(ClaimsPrincipal principal);

        // Створення GenerateRefreshToken
        public string GenerateRefreshToken();

        // Метод, що створює JWT токен на основі списку клеймів автентифікації 
        public JwtSecurityToken CreateToken(List<Claim> authClaims);
    }
}
