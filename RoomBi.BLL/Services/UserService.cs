using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace RoomBi.BLL.Services
{

    public class UserService : IServiceOfAll<UserDTO>, IServiceOfUser<UserDTO>
    { 
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(UserDTO userDTO)
        {

            var existingUsers = await Database.User.GetAll();
            var existingUser = existingUsers.FirstOrDefault(u => u.Email == userDTO.Email);

            if (existingUser != null)
            {
                if (existingUser.IsGoogleServiceUsed)
                {
                    throw new Exception("Користувач з таким email вже існує і він використовував сервіс Google для входу");
                }
                else
                {
                    throw new Exception("Користувач з таким email вже існує");
                }
            }
            var user = new User();
            if (userDTO.Password == "google")
            {
                user.Password = userDTO.Password;
                user.Email = userDTO.Email;
                user.IsGoogleServiceUsed = true;
            }
            else
            {
                // Generate a salt
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                // Generate the hashed password
                var pbkdf2 = new Rfc2898DeriveBytes(userDTO.Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                // Convert the byte array to a string
                string savedPasswordHash = Convert.ToBase64String(hash);
                user.Password = savedPasswordHash;
                user.Salt = Convert.ToBase64String(salt);// Save the salt
                user.Email = userDTO.Email;
                user.IsGoogleServiceUsed = false;
            }
            await Database.User.Create(user);
            await Database.Save();
        }


        public async Task Update(UserDTO userDTO)
        {
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
                Hash = userDTO.Hash,
                CurrentStatus = userDTO.CurrentStatus,
                UserStatus = userDTO.UserStatus,
                LanguageId = userDTO.LanguageId,
                CountryId = userDTO.CountryId
            };
            await Database.User.Update(user);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.User.Delete(id);
            await Database.Save();
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = await Database.User.Get(id);
            if (user == null)
                throw new ValidationException("Wrong user!", "");
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
                Hash = user.Hash,
                CurrentStatus = user.CurrentStatus,
                UserStatus = user.UserStatus,
                LanguageId = user.LanguageId,
                CountryId = user.CountryId
            };
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await Database.User.GetAll());
        }

       

        public async Task<UserDTO> GetByEmailAndPassword(string email, string password)
        {
            if (password == "google")
            {
                throw new Exception("Користувач був зареєстрований через сервіси Google.");
            }
            var users = await Database.User.GetAll();
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                throw new Exception("Користувач з таким email або password не існує");
            }

            var userDto = new UserDTO
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
                Hash = user.Hash,
                CurrentStatus = user.CurrentStatus,
                UserStatus = user.UserStatus,
                LanguageId = user.LanguageId,
                CountryId = user.CountryId
            };

            return userDto;
        }
    }
}
