using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class ProfileService : IServiceOfAll<ProfileDTO>, IServiceProfile<ProfileDTO>
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
                AboutMe = profileDTO.AboutMe,
                DailyActivity = profileDTO.DailyActivity,
                IdUser = profileDTO.IdUser
            };
            await Database.Profile.Create(profile);
            await Database.Save();
        }
        public async Task UpdateProfile(string fieldName, ProfileDTO profileDTO, int idUser)
        {
            var profile = await Database.Profile.Get(idUser);
            if (profile == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(profileDTO.SchoolYears)) profile.SchoolYears = profileDTO.SchoolYears;
            if (!string.IsNullOrEmpty(profileDTO.Pets)) profile.Pets = profileDTO.Pets;
            if (!string.IsNullOrEmpty(profileDTO.Job))profile.Job = profileDTO.Job;  
            if (!string.IsNullOrEmpty(profileDTO.MyLocation)) profile.MyLocation = profileDTO.MyLocation; 
            if (!string.IsNullOrEmpty(profileDTO.MyLanguages)) profile.MyLanguages = profileDTO.MyLanguages; 
            if (!string.IsNullOrEmpty(profileDTO.Generation)) profile.Generation = profileDTO.Generation;
            if (!string.IsNullOrEmpty(profileDTO.FavoriteSchoolSong))profile.FavoriteSchoolSong = profileDTO.FavoriteSchoolSong;  
            if (!string.IsNullOrEmpty(profileDTO.Passion)) profile.Passion = profileDTO.Passion; 
            if (!string.IsNullOrEmpty(profileDTO.InterestingFact))  profile.InterestingFact = profileDTO.InterestingFact;  
            if (!string.IsNullOrEmpty(profileDTO.UselessSkill)) profile.UselessSkill = profileDTO.UselessSkill; 
            if (!string.IsNullOrEmpty(profileDTO.BiographyTitle)) profile.BiographyTitle = profileDTO.BiographyTitle;
            if (!string.IsNullOrEmpty(profileDTO.DailyActivity)) profile.DailyActivity = profileDTO.DailyActivity; 
            if (!string.IsNullOrEmpty(profileDTO.AboutMe)) profile.AboutMe = profileDTO.AboutMe;  
 
            await Database.Profile.Update(profile);
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
                AboutMe = profileDTO.AboutMe,
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
                return null;
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
                AboutMe = profile.AboutMe,
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
