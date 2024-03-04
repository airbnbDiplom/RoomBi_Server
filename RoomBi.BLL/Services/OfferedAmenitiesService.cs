using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO.New;

namespace RoomBi.BLL.Services
{

    public class OfferedAmenitiesService : IServiceOfAll<OfferedAmenitiesDTO>
    {
        IUnitOfWork Database { get; set; }

        public OfferedAmenitiesService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task Create(OfferedAmenitiesDTO offeredAmenitiesDto)
        {
            var offeredAmenities = new OfferedAmenities
            {
                Id = offeredAmenitiesDto.Id,
                WiFi = offeredAmenitiesDto.WiFi,
                TV = offeredAmenitiesDto.TV,
                Kitchen = offeredAmenitiesDto.Kitchen,
                WashingMachine = offeredAmenitiesDto.WashingMachine,
                FreeParking = offeredAmenitiesDto.FreeParking,
                PaidParking = offeredAmenitiesDto.PaidParking,
                AirConditioner = offeredAmenitiesDto.AirConditioner,
                Workspace = offeredAmenitiesDto.Workspace,
                SpecialFeatures = offeredAmenitiesDto.SpecialFeatures,
                Pool = offeredAmenitiesDto.Pool,
                Jacuzzi = offeredAmenitiesDto.Jacuzzi,
                InnerYard = offeredAmenitiesDto.InnerYard,
                BBQArea = offeredAmenitiesDto.BBQArea,
                OutdoorDiningArea = offeredAmenitiesDto.OutdoorDiningArea,
                FirePit = offeredAmenitiesDto.FirePit,
                PoolTable = offeredAmenitiesDto.PoolTable,
                Fireplace = offeredAmenitiesDto.Fireplace,
                Piano = offeredAmenitiesDto.Piano,
                GymEquipment = offeredAmenitiesDto.GymEquipment,
                LakeAccess = offeredAmenitiesDto.LakeAccess,
                BeachAccess = offeredAmenitiesDto.BeachAccess,
                SkiInOut = offeredAmenitiesDto.SkiInOut,
                OutdoorShower = offeredAmenitiesDto.OutdoorShower,
                SmokeDetector = offeredAmenitiesDto.SmokeDetector,
                FirstAidKit = offeredAmenitiesDto.FirstAidKit,
                FireExtinguisher = offeredAmenitiesDto.FireExtinguisher,
                CarbonMonoxideDetector = offeredAmenitiesDto.CarbonMonoxideDetector,
                Description = offeredAmenitiesDto.Description
    };
            await Database.OfferedAmenities.Create(offeredAmenities);
            await Database.Save();
        }

        public async Task Update(OfferedAmenitiesDTO offeredAmenitiesDto)
        {
            var offeredAmenities = new OfferedAmenities
            {
                Id = offeredAmenitiesDto.Id,
                WiFi = offeredAmenitiesDto.WiFi,
                TV = offeredAmenitiesDto.TV,
                Kitchen = offeredAmenitiesDto.Kitchen,
                WashingMachine = offeredAmenitiesDto.WashingMachine,
                FreeParking = offeredAmenitiesDto.FreeParking,
                PaidParking = offeredAmenitiesDto.PaidParking,
                AirConditioner = offeredAmenitiesDto.AirConditioner,
                Workspace = offeredAmenitiesDto.Workspace,
                SpecialFeatures = offeredAmenitiesDto.SpecialFeatures,
                Pool = offeredAmenitiesDto.Pool,
                Jacuzzi = offeredAmenitiesDto.Jacuzzi,
                InnerYard = offeredAmenitiesDto.InnerYard,
                BBQArea = offeredAmenitiesDto.BBQArea,
                OutdoorDiningArea = offeredAmenitiesDto.OutdoorDiningArea,
                FirePit = offeredAmenitiesDto.FirePit,
                PoolTable = offeredAmenitiesDto.PoolTable,
                Fireplace = offeredAmenitiesDto.Fireplace,
                Piano = offeredAmenitiesDto.Piano,
                GymEquipment = offeredAmenitiesDto.GymEquipment,
                LakeAccess = offeredAmenitiesDto.LakeAccess,
                BeachAccess = offeredAmenitiesDto.BeachAccess,
                SkiInOut = offeredAmenitiesDto.SkiInOut,
                OutdoorShower = offeredAmenitiesDto.OutdoorShower,
                SmokeDetector = offeredAmenitiesDto.SmokeDetector,
                FirstAidKit = offeredAmenitiesDto.FirstAidKit,
                FireExtinguisher = offeredAmenitiesDto.FireExtinguisher,
                CarbonMonoxideDetector = offeredAmenitiesDto.CarbonMonoxideDetector,
                Description = offeredAmenitiesDto.Description
            };
            await Database.OfferedAmenities.Update(offeredAmenities);
            await Database.Save();
        }

        public async Task Delete(int id)
        {
            await Database.OfferedAmenities.Delete(id);
            await Database.Save();
        }

        public async Task<OfferedAmenitiesDTO> Get(int id)
        {
            var offeredAmenities = await Database.OfferedAmenities.Get(id);
            if (offeredAmenities == null)
                throw new ValidationException("Wrong offeredAmenities!", "");
            return new OfferedAmenitiesDTO
            {
                Id = offeredAmenities.Id,
                WiFi = offeredAmenities.WiFi,
                TV = offeredAmenities.TV,
                Kitchen = offeredAmenities.Kitchen,
                WashingMachine = offeredAmenities.WashingMachine,
                FreeParking = offeredAmenities.FreeParking,
                PaidParking = offeredAmenities.PaidParking,
                AirConditioner = offeredAmenities.AirConditioner,
                Workspace = offeredAmenities.Workspace,
                SpecialFeatures = offeredAmenities.SpecialFeatures,
                Pool = offeredAmenities.Pool,
                Jacuzzi = offeredAmenities.Jacuzzi,
                InnerYard = offeredAmenities.InnerYard,
                BBQArea = offeredAmenities.BBQArea,
                OutdoorDiningArea = offeredAmenities.OutdoorDiningArea,
                FirePit = offeredAmenities.FirePit,
                PoolTable = offeredAmenities.PoolTable,
                Fireplace = offeredAmenities.Fireplace,
                Piano = offeredAmenities.Piano,
                GymEquipment = offeredAmenities.GymEquipment,
                LakeAccess = offeredAmenities.LakeAccess,
                BeachAccess = offeredAmenities.BeachAccess,
                SkiInOut = offeredAmenities.SkiInOut,
                OutdoorShower = offeredAmenities.OutdoorShower,
                SmokeDetector = offeredAmenities.SmokeDetector,
                FirstAidKit = offeredAmenities.FirstAidKit,
                FireExtinguisher = offeredAmenities.FireExtinguisher,
                CarbonMonoxideDetector = offeredAmenities.CarbonMonoxideDetector,
                Description = offeredAmenities.Description
            };
        }

        public async Task<IEnumerable<OfferedAmenitiesDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OfferedAmenities, OfferedAmenitiesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OfferedAmenities>, IEnumerable<OfferedAmenitiesDTO>>(await Database.OfferedAmenities.GetAll());
        }

    }
}
