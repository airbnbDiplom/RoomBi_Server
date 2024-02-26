﻿using AutoMapper;
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

    public class UserService(IUnitOfWork uow) : IServiceOfAll<UserDTO>, IServiceOfUser<UserDTO>
    {
        IUnitOfWork Database { get; set; } = uow;
        public async Task<Boolean> GetBoolByEmail(string email)
        {
            var user = await Database.UserGetEmail.GetEmail(email);
            if (user != null) { throw new Exception("Користувач з таким email існує."); }
          
            return true;
        }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await Database.UserGetEmail.GetEmail(email);
            if (user == null)
                throw new NotImplementedException();
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
               Hash = user.Hash,
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
        public async Task<UserDTO> GetByEmailAndPassword(string email, string password)
        {
            //reg
            //Користувач з таким email існує

            //login
            //"Користувач був зареєстрований через сервіси Google."
            //Користувач з таким email або password не існує"

            //Користувач та його password "
            var user = await Database.UserGetEmail.GetEmail(email);
            if (password != "google" && user.Password == "google")
            {
                    throw new Exception("Користувач був зареєстрований через сервіси Google.");
            }
                var saltBytes = Convert.FromBase64String(user.Salt);
                var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
            string inputPasswordHash = Convert.ToBase64String(hash);

            if (user.Password != inputPasswordHash)
            {
                throw new Exception("Користувач з таким email або password не існує");
            }
            //var language = await Database.Languages.Get(user.LanguageId);
            //var contry = await Database.Country.Get(user.CountryId);
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
                Language = user.Language?.Name,
                Country = user.Country?.Name,

            };

          
        }
        public async Task<UserDTO> RegisterByEmailAndPassword(string email, string password)
        {
            var existingUsers = await Database.User.GetAll();
            var existingUser = existingUsers.FirstOrDefault(u => u.Email == email);

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
            if (password == "google")
            {
                user.Password = password;
                user.Email = email;
                user.IsGoogleServiceUsed = true;
            }
            else
            {
                // Generate a salt
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                // Generate the hashed password
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                // Convert the byte array to a string
                string savedPasswordHash = Convert.ToBase64String(hash);
                user.Password = savedPasswordHash;
                user.Salt = Convert.ToBase64String(salt);// Save the salt
                user.Email = email;
                user.IsGoogleServiceUsed = false;
            }
            await Database.User.Create(user);
            await Database.Save();
            var language = await Database.Languages.Get(user.LanguageId);
            var contry = await Database.Country.Get(user.CountryId);
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
                Language = language.Name,
                Country = contry.Name
            };

            return userDto;
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
                Hash = userDTO.Hash,
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
                Hash = user.Hash,
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
