using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

        public class EmergencyContactPersonService : IServiceOfAll<EmergencyContactPersonDTO>
        {
            IUnitOfWork Database { get; set; }

            public EmergencyContactPersonService(IUnitOfWork uow)
            {
                Database = uow;
            }

            public async Task Create(EmergencyContactPersonDTO emergencyContactPersonDTO)
            {
                var emergencyContactPerson = new EmergencyContactPerson
                {
                    Id = emergencyContactPersonDTO.Id,
                    Name = emergencyContactPersonDTO.Name,
                    Сonnection = emergencyContactPersonDTO.Сonnection,
                    PhoneNumber = emergencyContactPersonDTO.PhoneNumber,
                    CountryId = emergencyContactPersonDTO.CountryId,
                    IdUser = emergencyContactPersonDTO.IdUser
                };
                await Database.EmergencyContactPerson.Create(emergencyContactPerson);
                await Database.Save();
            }

            public async Task Update(EmergencyContactPersonDTO emergencyContactPersonDTO)
            {
                var emergencyContactPerson = new EmergencyContactPerson
                {
                    Id = emergencyContactPersonDTO.Id,
                    Name = emergencyContactPersonDTO.Name,
                    Сonnection = emergencyContactPersonDTO.Сonnection,
                    PhoneNumber = emergencyContactPersonDTO.PhoneNumber,
                    CountryId = emergencyContactPersonDTO.CountryId,
                    IdUser = emergencyContactPersonDTO.IdUser
                };
                await Database.EmergencyContactPerson.Update(emergencyContactPerson);
                await Database.Save();
            }

            public async Task Delete(int id)
            {
                await Database.EmergencyContactPerson.Delete(id);
                await Database.Save();
            }

            public async Task<EmergencyContactPersonDTO> Get(int id)
            {
                var emergencyContactPerson = await Database.EmergencyContactPerson.Get(id);
                if (emergencyContactPerson == null)
                    throw new ValidationException("Wrong emergencyContactPerson!", "");
                return new EmergencyContactPersonDTO
                {
                    Id = emergencyContactPerson.Id,
                    Name = emergencyContactPerson.Name,
                    Сonnection = emergencyContactPerson.Сonnection,
                    PhoneNumber = emergencyContactPerson.PhoneNumber,
                    CountryId = emergencyContactPerson.CountryId,
                    IdUser = emergencyContactPerson.IdUser
                };
            }

            public async Task<IEnumerable<EmergencyContactPersonDTO>> GetAll()
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmergencyContactPerson, EmergencyContactPersonDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<EmergencyContactPerson>, IEnumerable<EmergencyContactPersonDTO>>(await Database.EmergencyContactPerson.GetAll());
            }

        }
    }


