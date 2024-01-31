using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using RoomBi.DAL.Entities;

namespace RoomBi.BLL.Services
{
    public class LocationService : IServiceOfAll<LocationDTO>
    {
        IUnitOfWork Database { get; set; }

        public LocationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(LocationDTO locationDTO)
        {
            var location = new Location
            {
                Id = locationDTO.Id,
                Name = locationDTO.Name,
            };
            await Database.Location.Create(location);
            await Database.Save();
        }

        public async Task Update(LocationDTO locationDTO)
        {
            var location = new Location
            {
                Id = locationDTO.Id,
                Name = locationDTO.Name,
            };
            await Database.Location.Update(location);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Location.Delete(id);
            await Database.Save();
        }

        public async Task<LocationDTO> Get(int id)
        {
            var location = await Database.Location.Get(id);
            if (location == null)
                throw new ValidationException("Wrong location!", "");
            return new LocationDTO
            {
                Id = location.Id,
                Name = location.Name,
            };
        }

        public async Task<IEnumerable<LocationDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Location>, IEnumerable<LocationDTO>>(await Database.Location.GetAll());
        }

    }
}
