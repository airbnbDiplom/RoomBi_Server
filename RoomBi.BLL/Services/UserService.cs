﻿using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using System.Runtime.Intrinsics.X86;
using System.Net;

namespace RoomBi.BLL.Services
{

    public class UserService(IUnitOfWork uow) : IServiceOfAll<UserDTO>, IServiceOfUser<UserDTO>, IServiceOfUserGoogle<User>
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
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

                // Хешируем пароль с использованием PBKDF2
                var pbkdf2 = new Rfc2898DeriveBytes(user.Password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                // Комбинируем хеш и соль вместе
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);

                user.Password = Convert.ToBase64String(hashBytes);
                user.Salt = Convert.ToBase64String(salt);
                user.IsGoogleServiceUsed = false;
            }
            await Database.User.Create(user);
            await Database.Save();
        }
        public bool GetBoolByPassword(string password, string hashedPassword)
        {
            if (password == "google")
            {
                return true;
            }
            try
            {
                // Декодируем хеш и соль из строки
                byte[] hashedBytes = Convert.FromBase64String(hashedPassword);
                byte[] salt = new byte[16];
                Array.Copy(hashedBytes, 0, salt, 0, 16);

                // Хешируем введенный пользователем пароль с использованием соли из базы данных
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);

                // Сравниваем полученный хеш с хешем из базы данных
                for (int i = 0; i < 20; i++)
                {
                    if (hashedBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user = await Database.UserGetEmailAndPassword.GetEmail(email);
            if (user == null) { throw new Exception("Користувач з таким email не існує."); }
            var language = await Database.Languages.Get(user.LanguageId);
            var contry = await Database.Country.Get(user.CountryId);
            var profile = await Database.Profile.Get(user.Id);

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
                Country = contry.Name,
                Profile = profile,
            };

        }
        public async Task UpdateRefreshToken(UserDTO userDTO)
        {
            User user = await Database.User.Get(userDTO.Id);
            if (user != null)
            {
                user.RefreshToken = userDTO.RefreshToken;
                await Database.User.Update(user);
                await Database.Save();
            }
        }
        public async Task Delete(int id)
        {
            await Database.User.Delete(id);
            //await Database.Save();
        }
        public async Task<User> GetUserByGoogle(RequestUser item)
        {
            var user = await Database.UserGetEmailAndPassword.GetEmail(item.Email);
            if (user == null)
            {
                //var contry = await Database.CountryGetName.GetByName(item.Country);
                User user1 = new()
                {

                    Password = "google",
                    Email = item.Email,
                    Name = item.Name,
                    //PhoneNumber = item.PhoneNumber,
                    //DateOfBirth = DateTime.Parse(item.DateOfBirth),
                    AirbnbRegistrationYear = DateTime.Now,
                    //CountryId = contry.Id,
                    IsGoogleServiceUsed = true
                };
                await Database.User.Create(user1);
                await Database.Save();
                return user1;
            }
            return user;
        }
        //public async Task RegisterRequest(RequestUser requestUser)
        //{


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
        //}
        public async Task Update(UserDTO userDTO)
        {
            var user = await Database.UserGetEmailAndPassword.GetEmail(userDTO.Email);
            if (user != null)
            {
                if (userDTO.Name != "")
                    user.Name = userDTO.Name;
                //if (userDTO.Password != "")
                //    user.Password = userDTO.Password;//solt
                if (userDTO.Address != "")
                    user.Address = userDTO.Address;
                if (userDTO.PhoneNumber != "")
                    user.PhoneNumber = userDTO.PhoneNumber;
                if (userDTO.ProfilePicture != "")
                    user.ProfilePicture = userDTO.ProfilePicture;
                await Database.User.Update(user);
                await Database.Save();
            };

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
