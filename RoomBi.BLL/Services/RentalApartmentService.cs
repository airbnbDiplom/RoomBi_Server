using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using RoomBi.DAL.Entities;
using System;


namespace RoomBi.BLL.Services
{
    public class RentalApartmentService : IServiceOfAll<RentalApartmentDTO>, 
        IServiceForStartPage<RentalApartmentDTOForStartPage>
    {
        private readonly IUnitOfWork Database;
        private readonly GuestСommentsService guestСommentsService;

        public RentalApartmentService(IUnitOfWork uow, GuestСommentsService guestService)
        {
            Database = uow;
            guestСommentsService = guestService;
        }  
        public async Task Create(RentalApartmentDTO rentalApartmentDTO)
        {
            var rentalApartment = new RentalApartment
            {
                Id = rentalApartmentDTO.Id,
                Title = rentalApartmentDTO.Title,
                Address = rentalApartmentDTO.Address,
                IngMap = rentalApartmentDTO.IngMap,
                LatMap = rentalApartmentDTO.LatMap,
                NumberOfGuests = rentalApartmentDTO.NumberOfGuests,
                Bedrooms = rentalApartmentDTO.Bedrooms,
                Bathrooms = rentalApartmentDTO.Bathrooms,
                Beds = rentalApartmentDTO.Beds,
                PricePerNight = rentalApartmentDTO.PricePerNight,
                ObjectRating = rentalApartmentDTO.ObjectRating,
                ObjectState = rentalApartmentDTO.ObjectState,
                //OfferedAmenitiesId = rentalApartmentDTO.OfferedAmenitiesId,
                TypeApartment = rentalApartmentDTO.TypeApartment,
                //PropertyTypeId = rentalApartmentDTO.PropertyTypeId,
                //CountryId = rentalApartmentDTO.CountryId
            };
            await Database.RentalApartment.Create(rentalApartment);
            await Database.Save();
        }
        public async Task Update(RentalApartmentDTO rentalApartmentDTO)
        {
            var rentalApartment = new RentalApartment
            {
                Id = rentalApartmentDTO.Id,
                Title = rentalApartmentDTO.Title,
                Address = rentalApartmentDTO.Address,
                IngMap = rentalApartmentDTO.IngMap,
                LatMap = rentalApartmentDTO.LatMap,
                NumberOfGuests = rentalApartmentDTO.NumberOfGuests,
                Bedrooms = rentalApartmentDTO.Bedrooms,
                Bathrooms = rentalApartmentDTO.Bathrooms,
                Beds = rentalApartmentDTO.Beds,
                PricePerNight = rentalApartmentDTO.PricePerNight,
                ObjectRating = rentalApartmentDTO.ObjectRating,
                ObjectState = rentalApartmentDTO.ObjectState,
                //OfferedAmenitiesId = rentalApartmentDTO.OfferedAmenitiesId,
                TypeApartment = rentalApartmentDTO.TypeApartment,
                //PropertyTypeId = rentalApartmentDTO.PropertyTypeId,
                //CountryId = rentalApartmentDTO.CountryId
            };
            await Database.RentalApartment.Update(rentalApartment);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.RentalApartment.Delete(id);
            await Database.Save();
        }
        public async Task<RentalApartmentDTO> Get(int id)
        {
            var rentalApartment = await Database.RentalApartment.Get(id);
            if (rentalApartment == null)
                throw new ValidationException("Wrong rentalApartment!", "");
            Location location = await Database.Location.Get(rentalApartment.LocationId);
            Sport sport = await Database.Sport.Get(rentalApartment.SportId);
            House house = await Database.House.Get(rentalApartment.HouseId);
            Country country = await Database.Country.Get(rentalApartment.CountryId);
            OfferedAmenities offeredAmenities = await Database.OfferedAmenities.Get(rentalApartment.OfferedAmenitiesId);
            var guestCommentsForRentalItemDTO = await guestСommentsService.GetAllForRentalItem(id);
            return new RentalApartmentDTO
            {
                Id = rentalApartment.Id,
                Title = rentalApartment.Title,
                Address = rentalApartment.Address,
                IngMap = rentalApartment.IngMap,
                LatMap = rentalApartment.LatMap,
                NumberOfGuests = rentalApartment.NumberOfGuests,
                Bedrooms = rentalApartment.Bedrooms,
                Bathrooms = rentalApartment.Bathrooms,
                Beds = rentalApartment.Beds,
                PricePerNight = rentalApartment.PricePerNight,
                ObjectRating = rentalApartment.ObjectRating,
                ObjectState = rentalApartment.ObjectState,
                TypeApartment = rentalApartment.TypeApartment,

                Location = location.Name,
                Sport = sport.Name,
                House = house.Name,
                Country = country.Name,

                OfferedAmenities = offeredAmenities,
                Booking = null,
                GuestComments = (ICollection<GuestCommentsForRentalItemDTO>)guestCommentsForRentalItemDTO,
                Pictures = null,
                Chats = null




            };
        }
        public async Task<IEnumerable<RentalApartmentDTO>> GetAll()
        {
            var rentalApartments = await Database.RentalApartment.GetAll();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalApartment, RentalApartmentDTO>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
            }).CreateMapper();
            return mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentDTO>>(rentalApartments);
        }




        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllForStartPage()
        {
            var rentalApartments = await Database.RentalApartment.GetAll();
            List<RentalApartment> rentalApartmentListOld = new(rentalApartments);
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalApartment, RentalApartmentDTOForStartPage>()
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
            }).CreateMapper();

            var temp = mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentDTOForStartPage>>(rentalApartments);
            List<RentalApartmentDTOForStartPage> rentalApartmentList = new(temp);

            for (int i = 0; i < rentalApartmentList.Count; i++)
            {
                rentalApartmentList[i].Country += ", " + rentalApartmentListOld[i].Address;
                rentalApartmentList[i].BookingFree = FormatDate(rentalApartmentListOld[i]);
            }
            return rentalApartmentList;
        }
        public static string FormatDate(RentalApartment rentalApartment)
        {
            List<Booking> booking = (List<Booking>)rentalApartment.Booking;
            DateTime lastCheckOutDate = DateTime.MinValue;
            for (int i = 0; i < booking.Count; i++)
            {
                DateTime currentCheckOutDate = booking[i].CheckOutDate;
                Console.WriteLine("currentCheckOutDate = " + currentCheckOutDate);
                if (i < booking.Count - 1)
                {
                    DateTime nextCheckInDate = booking[i + 1].CheckInDate;
                    Console.WriteLine("nextCheckInDate = " + nextCheckInDate);
                    TimeSpan difference = nextCheckInDate - currentCheckOutDate;
                    Console.WriteLine("difference = " + difference);
                    if (difference.Days >= 5)
                    {
                        lastCheckOutDate = currentCheckOutDate;
                        Console.WriteLine("ans = " + currentCheckOutDate);
                    }
                }
                else if (lastCheckOutDate == DateTime.MinValue)
                {
                    lastCheckOutDate = currentCheckOutDate;
                }
                
            }
            DateTime newDate = lastCheckOutDate.AddDays(5);
            string formattedDate = lastCheckOutDate.ToString("dd", new System.Globalization.CultureInfo("uk-UA")) + "-" +
            newDate.ToString("dd MMM", new System.Globalization.CultureInfo("uk-UA"));
            Console.WriteLine("formattedDate = " + formattedDate);
            return formattedDate;
        }

    }
}
