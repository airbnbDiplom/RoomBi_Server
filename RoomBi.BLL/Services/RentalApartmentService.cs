using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using RoomBi.DAL.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;


namespace RoomBi.BLL.Services
{
    public class RentalApartmentService : IServiceOfAll<RentalApartmentDTO>,
        IServiceForStartPage<RentalApartmentDTOForStartPage>
    {
        private readonly IUnitOfWork Database;
        public RentalApartmentService(IUnitOfWork uow)
        {
            Database = uow;
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
            User user = await Database.User.Get(rentalApartment.UserId);
            Language language = await Database.Languages.Get(user.LanguageId);
            ICollection<GuestCommentsForRentalItemDTO> guestCommentsMapper = await GuestCommentsMapper(rentalApartment.GuestComments);
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
                MasterName = user.Name,
                AirbnbRegistrationYear = FormatAirbnbRegistration(user.AirbnbRegistrationYear ), 
                MasterLanguage = language.Name,
                Avatar = user.ProfilePicture,
                Location = location.Name,
                Sport = sport.Name,
                House = house.Name,
                Country = country.Name,
                OfferedAmenities = offeredAmenities,
                GuestComments = guestCommentsMapper,
                Pictures = rentalApartment.Pictures,
                Booking = BookingMapper(rentalApartment.Booking)
            };
        }
        static public ICollection<BookingForApartmentPageDTO> BookingMapper(IEnumerable<Booking> rentalApartment)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingForApartmentPageDTO>();
            }).CreateMapper();
            return (ICollection<BookingForApartmentPageDTO>)mapper.Map<IEnumerable<Booking>, IEnumerable<BookingForApartmentPageDTO>>(rentalApartment);
        }
        public async Task<ICollection<GuestCommentsForRentalItemDTO>> GuestCommentsMapper(IEnumerable<GuestComments> rentalApartment)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestComments, GuestCommentsForRentalItemDTO>()
                     .ForMember(dest => dest.UserName, opt => opt.Ignore()) 
                     .ForMember(dest => dest.UserCountry, opt => opt.Ignore())
                     .ForMember(dest => dest.UserAvatar, opt => opt.Ignore());
            }).CreateMapper();

            ICollection<GuestCommentsForRentalItemDTO> guestCommentsMapper = (ICollection<GuestCommentsForRentalItemDTO>)mapper.Map<IEnumerable<GuestComments>, IEnumerable<GuestCommentsForRentalItemDTO>>(rentalApartment);
            foreach (var comment in guestCommentsMapper)
            {
                User user = await Database.User.Get(comment.GuestIdUser);
                comment.UserName = user.Name;
                comment.UserAvatar = user.ProfilePicture;
                Country country = await Database.Country.Get(user.CountryId);
                comment.UserCountry = country.Name;
            }
            return guestCommentsMapper;
        }
        static public string FormatAirbnbRegistration(DateTime? AirbnbRegistrationYear)
        {
            if (AirbnbRegistrationYear.HasValue)
            {
                CultureInfo culture = new CultureInfo("uk-UA");
                return "Вступ до спільноти: " + AirbnbRegistrationYear.Value.ToString("MMMM yyyy", culture) + " р";
            }
            else
            {
                return "Вступ до спільноти: невідомо";
            }
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
