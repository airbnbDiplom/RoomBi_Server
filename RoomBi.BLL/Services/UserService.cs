using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace RoomBi.BLL.Services
{

    public class UserService(IUnitOfWork uow) : IServiceOfAll<UserDTO>, IServiceOfUser<UserDTO>
    {
        IUnitOfWork Database { get; set; } = uow;
        public async Task<Boolean> GetBoolByEmail(string email)
        {
            var user = await Database.UserGetEmailAndPassword.GetEmail(email);
            if (user != null) { throw new Exception("Користувач з таким email існує."); }
            return true;
        }
        public async Task Create(UserDTO userDto)
        {
            var temp = await Database.UserGetEmailAndPassword.GetEmail(userDto.Email);
            if (temp != null)
            {
                if (temp.IsGoogleServiceUsed)
                {
                    throw new Exception("Користувач з таким email вже існує і він використовував сервіс Google для входу");
                }
                else
                {
                    throw new Exception("Користувач з таким email вже існує");
                }
            }
            var contry = await Database.CountryGetName.GetByName(userDto.Country);
            User user = new()
            {
                Password = userDto.Password,
                Email = userDto.Email,
                //RefreshToken = userDto.RefreshToken,
                Name = userDto.Name,
                PhoneNumber = userDto.PhoneNumber,
                DateOfBirth = userDto.DateOfBirth,
                AirbnbRegistrationYear = DateTime.Now,
                CountryId = contry.Id
            };
            if (userDto.Password == "google")
            {
                user.IsGoogleServiceUsed = true;
            }
            else
            {
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                user.Password = Convert.ToBase64String(hash);
                user.Salt = Convert.ToBase64String(salt);
                user.IsGoogleServiceUsed = false;
            }
            await Database.User.Create(user);
            await Database.Save();
        }

        public async Task<Boolean> GetBoolByPassword(string password)
        {
            var user = await Database.UserGetEmailAndPassword.GetPassword(password); 
            if (user == null)
            {
                throw new Exception("Користувач не знайден.");
            }
            if (user.Password == "google")
            {
                return true;
            }
            byte[] savedHash = Convert.FromBase64String(user.Password);
            byte[] savedSalt = Convert.FromBase64String(user.Salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, savedSalt, 10000);
            byte[] newHash = pbkdf2.GetBytes(20);
            return newHash.SequenceEqual(savedHash);
        }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await Database.UserGetEmailAndPassword.GetEmail(email);
            if (user == null) { throw new Exception("Користувач з таким email не існує."); }
            var language = await Database.Languages.Get(user.LanguageId);
            var contry = await Database.Country.Get(user.CountryId);
            return new UserDTO
           {
               Id = user.Id,
               Name = user.Name,
               Password = user.Password,
               Email = user.Email,
               Address = user.Address,
               PhoneNumber = user.PhoneNumber,
               DateOfBirth = user.DateOfBirth,
               AirbnbRegistrationYear = user.AirbnbRegistrationYear,
               ProfilePicture = user.ProfilePicture,
               RefreshToken = user.RefreshToken,
               CurrentStatus = user.CurrentStatus,
               UserStatus = user.UserStatus,
               Language = language.Name,
               Country = contry.Name
           };

        }
        public async Task UpdateRefreshToken(UserDTO userDTO)
        {
            User user = await Database.User.Get(userDTO.Id);
            user.RefreshToken = userDTO.RefreshToken;
            await Database.User.Update(user);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.User.Delete(id);
            //await Database.Save();
        }
       




    public async Task RegisterRequest(RequestUser requestUser)
        {
  

            //    byte[] salt;
            //    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //    // Generate the hashed password
            //    var pbkdf2 = new Rfc2898DeriveBytes(userDTO.Password, salt, 10000);
            //    byte[] hash = pbkdf2.GetBytes(20);

            //    // Convert the byte array to a string
            //    string savedPasswordHash = Convert.ToBase64String(hash);
            //    user.Password = savedPasswordHash;
            //    user.Salt = Convert.ToBase64String(salt);// Save the salt
            //    user.Email = userDTO.Email;
            //    user.IsGoogleServiceUsed = false;
            ////}
            //await Database.User.Create(user);
            //await Database.Save();


            //if (userDTO.Password == "google")
            //{
            //    user.Password = userDTO.Password;
            //    user.Email = userDTO.Email;
            //    user.IsGoogleServiceUsed = true;
            //}
            //else
            //{
            // Generate a salt
        }
        public async Task Update(UserDTO userDTO)
        {
            var language = await Database.LanguageGetName.GetByName(userDTO.Language);
            var contry = await Database.CountryGetName.GetByName(userDTO.Country);
            var user = new User
            {
                Id = userDTO.Id,
                Name = userDTO.Name,
                Password = userDTO.Password,
                Email = userDTO.Email,
                Address = userDTO.Address,
                PhoneNumber = userDTO.PhoneNumber,
                DateOfBirth = userDTO.DateOfBirth,
                AirbnbRegistrationYear = userDTO.AirbnbRegistrationYear,
                ProfilePicture = userDTO.ProfilePicture,
                RefreshToken = userDTO.RefreshToken,
                CurrentStatus = userDTO.CurrentStatus,
                UserStatus = userDTO.UserStatus,
                LanguageId = language.Id,
                CountryId = contry.Id
            };
            await Database.User.Update(user);
            await Database.Save();
        }
        public async Task<UserDTO> Get(int id)
        {

            var user = await Database.User.Get(id);
            if (user == null)
                throw new ValidationException("Wrong user!", "");
            var language = await Database.Languages.Get(user.LanguageId);
            var contry = await Database.Country.Get(user.CountryId);
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                AirbnbRegistrationYear = user.AirbnbRegistrationYear,
                ProfilePicture = user.ProfilePicture,
                RefreshToken = user.RefreshToken,
                CurrentStatus = user.CurrentStatus,
                UserStatus = user.UserStatus,
                Language = language.Name,
                Country = contry.Name
            };
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await Database.User.GetAll());
        }

     
    }
}
