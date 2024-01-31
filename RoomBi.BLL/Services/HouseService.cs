using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;


namespace RoomBi.BLL.Services
{
    public class HouseService : IServiceOfAll<HouseDTO>
    {
        IUnitOfWork Database { get; set; }

        public HouseService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(HouseDTO houseDTO)
        {
            var house = new House
            {
                Id = houseDTO.Id,
                Name = houseDTO.Name,
            };
            await Database.House.Create(house);
            await Database.Save();
        }

        public async Task Update(HouseDTO HouseDTO)
        {
            var House = new House
            {
                Id = HouseDTO.Id,
                Name = HouseDTO.Name,
            };
            await Database.House.Update(House);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.House.Delete(id);
            await Database.Save();
        }

        public async Task<HouseDTO> Get(int id)
        {
            var house = await Database.House.Get(id);
            if (house == null)
                throw new ValidationException("Wrong propertyType!", "");
            return new HouseDTO
            {
                Id = house.Id,
                Name = house.Name,
            };

        }

        public async Task<IEnumerable<HouseDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<House, HouseDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<House>, IEnumerable<HouseDTO>>(await Database.House.GetAll());
        }

    }
}

