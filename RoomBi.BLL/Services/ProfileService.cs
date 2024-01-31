using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class ProfileService : IServiceOfAll<ProfileDTO>
    {
        IUnitOfWork Database { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(ProfileDTO profileDTO)
        {
            var profile = new RoomBi.DAL.Profile
            {
                Id = profileDTO.Id,
                SchoolYears = profileDTO.SchoolYears,
                Pets = profileDTO.Pets,
                Job = profileDTO.Job,
                MyLanguages = profileDTO.MyLanguages,
                MyLocation = profileDTO.MyLocation,
                Generation = profileDTO.Generation,
                FavoriteSchoolSong = profileDTO.FavoriteSchoolSong,
                Passion = profileDTO.Passion,
                InterestingFact = profileDTO.InterestingFact,
                UselessSkill = profileDTO.UselessSkill,
                BiographyTitle = profileDTO.BiographyTitle,
                DailyActivity = profileDTO.DailyActivity,
                IdUser = profileDTO.IdUser
            };
            await Database.Profile.Create(profile);
            await Database.Save();
        }

        public async Task Update(ProfileDTO profileDTO)
        {
            var profile = new RoomBi.DAL.Profile
            {
                Id = profileDTO.Id,
                SchoolYears = profileDTO.SchoolYears,
                Pets = profileDTO.Pets,
                Job = profileDTO.Job,
                MyLanguages = profileDTO.MyLanguages,
                MyLocation = profileDTO.MyLocation,
                Generation = profileDTO.Generation,
                FavoriteSchoolSong = profileDTO.FavoriteSchoolSong,
                Passion = profileDTO.Passion,
                InterestingFact = profileDTO.InterestingFact,
                UselessSkill = profileDTO.UselessSkill,
                BiographyTitle = profileDTO.BiographyTitle,
                DailyActivity = profileDTO.DailyActivity,
                IdUser = profileDTO.IdUser
            };
            await Database.Profile.Update(profile);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Profile.Delete(id);
            await Database.Save();
        }

        public async Task<ProfileDTO> Get(int id)
        {
            var profile = await Database.Profile.Get(id);
            if (profile == null)
                throw new ValidationException("Wrong profile!", "");
            return new ProfileDTO
            {
                Id = profile.Id,
                SchoolYears = profile.SchoolYears,
                Pets = profile.Pets,
                Job = profile.Job,
                MyLanguages = profile.MyLanguages,
                MyLocation = profile.MyLocation,
                Generation = profile.Generation,
                FavoriteSchoolSong = profile.FavoriteSchoolSong,
                Passion = profile.Passion,
                InterestingFact = profile.InterestingFact,
                UselessSkill = profile.UselessSkill,
                BiographyTitle = profile.BiographyTitle,
                DailyActivity = profile.DailyActivity,
                IdUser = profile.IdUser,
            };
        }

        public async Task<IEnumerable<ProfileDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RoomBi.DAL.Profile, ProfileDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<RoomBi.DAL.Profile>, IEnumerable<ProfileDTO>>(await Database.Profile.GetAll());
        }

    }
}
