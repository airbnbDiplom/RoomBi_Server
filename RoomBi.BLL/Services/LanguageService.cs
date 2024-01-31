using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class LanguageService : IServiceOfAll<LanguageDTO>
    {
        IUnitOfWork Database { get; set; }

        public LanguageService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(LanguageDTO languageDTO)
        {
            var language = new Language
            {
                Id = languageDTO.Id,
                Name = languageDTO.Name
            };
            await Database.Languages.Create(language);
            await Database.Save();
        }

        public async Task Update(LanguageDTO languageDTO)
        {
            var language = new Language
            {
                Id = languageDTO.Id,
                Name = languageDTO.Name
            };
            await Database.Languages.Update(language);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Languages.Delete(id);
            await Database.Save();
        }

        public async Task<LanguageDTO> Get(int id)
        {
            var language = await Database.Languages.Get(id);
            if (language == null)
                throw new ValidationException("Wrong language!", "");
            return new LanguageDTO
            {
                Id = language.Id,
                Name = language.Name
            };
        }
        
        public async Task<IEnumerable<LanguageDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Language, LanguageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Language>, IEnumerable<LanguageDTO>>(await Database.Languages.GetAll());
        }

    }
}
