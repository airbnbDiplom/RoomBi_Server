using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoomBi.BLL.DTO;
using RoomBi.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RoomBi_Server.Token
{
    public class JwtTokenService : IJwtToken
    {
        private readonly IConfiguration _configuration;
        String Secret;
        String Issuer;
        String Audience;
        int Expire;


        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            var gmailConfig = _configuration.GetSection("Jwt");          // Отримання конфігурації JWT з файлу налаштувань
            this.Secret = gmailConfig.GetValue<String>("Secret")!;       // Отримання секретного ключа для підпису JWT
            this.Issuer = gmailConfig.GetValue<String>("Issuer")!;       // Отримання власника JWT
            this.Audience = gmailConfig.GetValue<String>("Audience")!;   // Отримання аудиторії JWT
            this.Expire = gmailConfig.GetValue<int>("Expire");           // Отримання часу життя JWT у хвилинах
        }

        public string GetToken(UserDTO user)
        {
            
            var claims = new List<Claim>
             {
                new("Id", user.Id.ToString()),
                user.Name != null ? new Claim("Name", user.Name) : new Claim("Name", ""),
                user.Email != null ? new Claim("Email", user.Email) : new Claim("Email", ""),
                new("ProfilePicture", user.ProfilePicture ?? ""),
                user.Language != null ? new Claim("Language", user.Language) : new Claim("Language", ""),
                user.Country != null ? new Claim("Country", user.Country) : new Claim("Country", "")
            };


            // Створення симетричного ключа для підпису JWT на основі секретного ключа
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Secret));

            var token = new JwtSecurityToken( // Створення JWT з відповідними параметрами
               issuer: this.Issuer,
               audience: this.Audience,
               claims: claims,
               expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(this.Expire)),
               notBefore: DateTime.UtcNow,
               signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
           );

            // Повернення JWT у вигляді рядка
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //оновлення токену та   пееревірка валідності підпису токену 
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string? token)
        {
            // Налаштування параметрів перевірки токена
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,            // Вимкнення перевірки аудиторії
                ValidateIssuer = false,              // Вимкнення перевірки власника
                ValidateIssuerSigningKey = true,     // Включення перевірки підпису власного ключа
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret)),  // Встановлення симетричного ключа для перевірки підпису
                ValidateLifetime = false             // Вимкнення перевірки часу життя токена
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // Перевірка токена з використанням встановлених параметрів
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            // Перевірка, чи токен використовує алгоритм підпису HmacSha256
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            // Повертаємо представлення клеймів користувача
            return principal;
        }
        public UserDTO GetUserInfoFromToken(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            UserDTO userInfo = new UserDTO();

            foreach (var claim in principal.Claims)
            {
                switch (claim.Type)
                {
                    case "Id":
                        userInfo.Id = int.Parse(claim.Value);
                        break;
                    case "Name":
                        userInfo.Name = claim.Value;
                        break;
                    case "Email":
                        userInfo.Email = claim.Value;
                        break;
                    case "ProfilePicture":
                        userInfo.ProfilePicture = claim.Value;
                        break;
                    case "Country":
                        userInfo.Country = claim.Value;
                        break;
                    case "Language":
                        userInfo.Language = claim.Value;
                        break;
                }
            }
            return userInfo;
        }

        //отримати пошту з токену
        public string GetMailFromToken(ClaimsPrincipal principal)
        {
            string email = "";
            var claims = principal.Claims;
            // Для кожного клейму вивести ключ та значення
            foreach (var claim in claims)
            {
                if (claim.Type == "Email")
                {
                    email = claim.Value;
                    return email;
                }
                   
            }
            return email;
        }
        public int GetIdFromToken(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            int id = 1;
            var claims = principal.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == "Id")
                {
                    id = int.Parse(claim.Value);
                    return id;
                }
            }
            return id;
        }
        // Створення GenerateRefreshToken
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        // Метод, що створює JWT токен на основі списку клеймів автентифікації 
        public JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            // Створення симетричного ключа для підпису JWT на основі секретного ключа
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Secret));

            var token = new JwtSecurityToken(// Створення JWT з відповідними параметрами
                issuer: this.Issuer,
                audience: this.Audience,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(this.Expire)),
                claims: authClaims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return token;  // Повертаємо створений JWT токен.
        }

       
    }
}
