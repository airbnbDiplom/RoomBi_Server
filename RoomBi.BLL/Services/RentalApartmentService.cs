using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using System.Globalization;
using RoomBi.BLL.DTO.New;
using Azure;


namespace RoomBi.BLL.Services
{
    public class RentalApartmentService(IUnitOfWork uow) : 
        IServiceForItem<RentalApartmentDTO>,
        IServiceForStartPage<RentalApartmentDTOForStartPage>,
        IServiceForMap<RentalApartmentForMap>
    {
        private readonly IUnitOfWork Database = uow;

        public async Task<RentalApartmentDTO> GetItem(int id, int userId)
        {
            var rentalApartment = await Database.RentalApartment.Get(id);
            if (rentalApartment == null)
                throw new ValidationException("Wrong rentalApartment!", "");
            User user = await Database.User.Get(rentalApartment.UserId);
            Language language = await Database.Languages.Get(user.LanguageId);
            Country country = await Database.Country.Get(user.CountryId);

            ICollection<GuestComments> guestCommentsCollection = rentalApartment.GuestComments;
            ICollection<GuestСommentsDTO> guestCommentsDTOCollection = new List<GuestСommentsDTO>();
            foreach (var guestComment in guestCommentsCollection)
            {
                User user2 = await Database.User.Get(guestComment.GuestIdUser);
                Country country2 = await Database.Country.Get(user2.CountryId);
                var guestCommentDTO = new GuestСommentsDTO
                {
                    Id = guestComment.Id,
                    GuestIdUser = guestComment.GuestIdUser,
                    UserName = user2.Name,
                    UserCountry = country2.Name,
                    UserAvatar = user2.ProfilePicture,
                    Comment = guestComment.Comment,
                    DateTime = guestComment.DateTime,
                    Rating = guestComment.Rating
                };
                guestCommentsDTOCollection.Add(guestCommentDTO);
            }
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

                Location = rentalApartment.Location?.Name,
                Sport = rentalApartment.Sport?.Name,
                House = rentalApartment.House?.Name,
                Country = rentalApartment.Country?.Name,
                Wish = await Database.GetItemWishlist.CheckIfWishlistItemExists(userId, rentalApartment.Id),

                OfferedAmenities = rentalApartment.OfferedAmenities,
                Master = MapUserToMaster(user, language, country),
                GuestComments = guestCommentsDTOCollection,
                Pictures = rentalApartment.Pictures,
                DateBooking = ConvertBookingsToDates(rentalApartment.Booking),
            };
        }
        public static List<DateBooking> ConvertBookingsToDates(ICollection<Booking> bookings)
        {
            var dateBookings = new List<DateBooking>();

            foreach (var booking in bookings)
            {
                if (booking.PaymentStatus)
                {
                    var dateBooking = new DateBooking(booking.CheckInDate, booking.CheckOutDate);
                    dateBookings.Add(dateBooking);
                }
            }

            return dateBookings;
        }
        public static MasterForApartmentPage MapUserToMaster(User user, Language language, Country country)
        {
            int hostingGuests = 0;
            if (user.AirbnbRegistrationYear.HasValue)
            {
                var yearsHostingGuests = DateTime.Now.Year - user.AirbnbRegistrationYear.Value.Year;
                hostingGuests = yearsHostingGuests;
            }
            return new MasterForApartmentPage()
            {
                Id = user.Id,
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                ProfilePicture = user.ProfilePicture,
                CurrentStatus = user.CurrentStatus,
                Language = language.Name,
                Country = country.Name,
                HostingGuests = hostingGuests,
                JoiningTheCommunity = user.AirbnbRegistrationYear?.Year.ToString()

            };
        }
        public async Task<RentalApartmentDTOForStartPage> GetCard(int id)
        {
            var rentalApartment = await Database.RentalApartment.Get(id);
            if (rentalApartment == null)
                throw new ValidationException("Wrong rentalApartment!", "");
            return new RentalApartmentDTOForStartPage
            {
                Id = rentalApartment.Id,
                Title = rentalApartment.Title,
                IngMap = rentalApartment.IngMap,
                LatMap = rentalApartment.LatMap,
                PricePerNight = rentalApartment.PricePerNight,
                ObjectRating = rentalApartment.ObjectRating,
                Location = rentalApartment.Location?.Name,
                Sport = rentalApartment.Sport?.Name,
                House = rentalApartment.House?.Name,
                Country = rentalApartment.Country?.Name,
                Pictures = rentalApartment.Pictures,
                BookingFree = null
            };
        }

        public async Task<IEnumerable<RentalApartmentForMap>> GetAllForMap(string map)
        {
            var rentalApartments = await Database.RentalApartment.GetAll();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalApartment, RentalApartmentForMap>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.House, opt => opt.MapFrom(src => src.House.Name))
                .ForMember(dest => dest.Sport, opt => opt.MapFrom(src => src.Sport.Name));

            }).CreateMapper();
            return mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentForMap>>(rentalApartments);
        }
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllForStartPage(int page, int pageSize, int idUser)
        {
            if (page == 1)
            {
                var rentalApartments = await Database.Apartment24.Get24(page, pageSize);
                List<RentalApartmentDTOForStartPage> rentalApartmentList = [];
                foreach (var apartment in rentalApartments)
                {
                    var rentalApartmentDto = new RentalApartmentDTOForStartPage
                    {
                        Id = apartment.Id,
                        Title = apartment.Title,
                        IngMap = apartment.IngMap,
                        LatMap = apartment.LatMap,
                        PricePerNight = apartment.PricePerNight,
                        ObjectRating = apartment.ObjectRating,
                        Country = apartment.Country?.Name + ", " + apartment.Address,
                        Wish = await Database.GetItemWishlist.CheckIfWishlistItemExists(idUser, apartment.Id),
                        Location = apartment.Location?.Name,
                        House = apartment.House?.Name,
                        Sport = apartment.Sport?.Name,
                        Pictures = apartment.Pictures, 
                        BookingFree = FormatDate(apartment)

                    };

                    rentalApartmentList.Add(rentalApartmentDto);
                }
                return rentalApartmentList;
            }
            else
            {
                var rentalApartments = await Database.RentalApartment.GetAll();
                List<RentalApartmentDTOForStartPage> rentalApartmentList = [];
                foreach (var apartment in rentalApartments)
                {
                    var rentalApartmentDto = new RentalApartmentDTOForStartPage
                    {
                        Id = apartment.Id,
                        Title = apartment.Title,
                        IngMap = apartment.IngMap,
                        LatMap = apartment.LatMap,
                        PricePerNight = apartment.PricePerNight,
                        ObjectRating = apartment.ObjectRating,
                        Country = apartment.Country?.Name + ", " + apartment.Address,
                        Location = apartment.Location?.Name,
                        House = apartment.House?.Name,
                        Sport = apartment.Sport?.Name,
                        Pictures = apartment.Pictures,
                        BookingFree = FormatDate(apartment)

                    };
                    rentalApartmentList.Add(rentalApartmentDto);
                }

                return rentalApartmentList;
            }
        }
        public static string FormatDate(RentalApartment rentalApartment)
        {
            if (rentalApartment.Booking == null || rentalApartment.Booking.Count == 0)
            {
                DateTime date = DateTime.Now;
                DateTime newDate = date.AddDays(5);
                string formattedDate = date.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                        " - " +
                                        newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                return formattedDate;
            }
            var bookings = rentalApartment.Booking.OrderBy(b => b.CheckOutDate).ToList();
            DateTime datenow = DateTime.Now;
            DateTime first = bookings.First().CheckInDate;
            TimeSpan difference1 = first - datenow;
            if (difference1.Days >= 5)
            {
                DateTime newDate = datenow.AddDays(5);
                string formattedDate = datenow.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                        " - " +
                                        newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                return formattedDate;
            }
            DateTime lastCheckOutDate = bookings.First().CheckOutDate;
            foreach (var booking in bookings.Skip(1))
            {
                DateTime nextCheckInDate = booking.CheckInDate;
                TimeSpan difference = nextCheckInDate - lastCheckOutDate;
                if (difference.Days >= 5)
                {
                    DateTime newDate = lastCheckOutDate.AddDays(5);
                    string formattedDate = lastCheckOutDate.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                            " - " +
                                            newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                    return formattedDate;
                }
                lastCheckOutDate = booking.CheckOutDate;
            }
            DateTime newDate1 = lastCheckOutDate.AddDays(5);
            string formattedDate1 = lastCheckOutDate.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                    " - " +
                                    newDate1.ToString("dd MMM", new CultureInfo("uk-UA"));
            return formattedDate1;

        }

        public async Task Delete(int id)
        {
            await Database.RentalApartment.Delete(id);
            await Database.Save();
        }

        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllForMaster(int idUser)
        {
            var rentalApartments = await Database.SearchRentalApartment.GetObjectsByUserId(idUser);
            List<RentalApartmentDTOForStartPage> rentalApartmentList = [];
            foreach (var apartment in rentalApartments)
            {
                var rentalApartmentDto = new RentalApartmentDTOForStartPage
                {
                    Id = apartment.Id,
                    Title = apartment.Title,
                    IngMap = apartment.IngMap,
                    LatMap = apartment.LatMap,
                    PricePerNight = apartment.PricePerNight,
                    ObjectRating = apartment.ObjectRating,
                    Country = apartment.Country?.Name + ", " + apartment.Address,
                    Wish = await Database.GetItemWishlist.CheckIfWishlistItemExists(idUser, apartment.Id),
                    Location = apartment.Location?.Name,
                    House = apartment.House?.Name,
                    Sport = apartment.Sport?.Name,
                    Pictures = apartment.Pictures,
                    BookingFree = FormatDate(apartment)

                };

                rentalApartmentList.Add(rentalApartmentDto);
            }
            return rentalApartmentList;
           
        }
    }
}
