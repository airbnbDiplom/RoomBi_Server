using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using Newtonsoft.Json.Linq;

namespace RoomBi.BLL.Services
{

    public class UserService : IServiceOfAll<UserDTO>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(UserDTO userDTO)
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
                CurrentStatus = userDTO.CurrentStatus,
                RefreshToken = userDTO.RefreshToken,
                Hash = userDTO.Hash,
                UserStatus = userDTO.UserStatus,
                LanguageId = userDTO.LanguageId,
                CountryId = userDTO.CountryId
            };
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

    }
}
