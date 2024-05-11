using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;

namespace RoomBi.BLL.Services
{

    public class CountryService(IUnitOfWork uow) : IServiceOfAll<CountryDTO>
    {
        IUnitOfWork Database { get; set; } = uow;

        public async Task Create(CountryDTO countryDto)
        {
            var country = new Country
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                PhoneCode = countryDto.PhoneCode
            };
            await Database.Country.Create(country);
            await Database.Save();
        }

        public async Task Update(CountryDTO countryDto)
        {
            var country = new Country
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                PhoneCode = countryDto.PhoneCode
            };
            await Database.Country.Update(country);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.Country.Delete(id);
            await Database.Save();
        }

        public async Task<CountryDTO> Get(int id)
        {
            var country = await Database.Country.Get(id);
            if (country == null)
                throw new ValidationException("Wrong country!", "");
            return new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
                PhoneCode = country.PhoneCode
            };
        }

        public async Task<IEnumerable<CountryDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(await Database.Country.GetAll());
        }

    }
}


