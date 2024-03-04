using AutoMapper;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL.Interfaces;
using RoomBi.BLL.Infrastructure;
using RoomBi.DAL.Entities;
using RoomBi.BLL.DTO.New;

namespace RoomBi.BLL.Services
{
    public class SportService : IServiceOfAll<SportDTO>
    {
        IUnitOfWork Database { get; set; }

        public SportService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(SportDTO sportDTO)
        {
            var sport = new Sport
            {
                Id = sportDTO.Id,
                Name = sportDTO.Name,
            };
            await Database.Sport.Create(sport);
            await Database.Save();
        }

        public async Task Update(SportDTO sportDTO)
        {
            var sport = new Sport
            {
                Id = sportDTO.Id,
                Name = sportDTO.Name,
            };
            await Database.Sport.Update(sport);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Sport.Delete(id);
            await Database.Save();
        }

        public async Task<SportDTO> Get(int id)
        {
            var sport = await Database.Sport.Get(id);
            if (sport == null)
                throw new ValidationException("Wrong Sport!", "");
            return new SportDTO
            {
                Id =sport.Id,
                Name = sport.Name,
            };
        }

        public async Task<IEnumerable<SportDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sport, SportDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Sport>, IEnumerable<SportDTO>>(await Database.Sport.GetAll());
        }

    }
}

