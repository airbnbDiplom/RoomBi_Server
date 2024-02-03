using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;
using RoomBi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class EFUnitOfWork(RBContext context) : IUnitOfWork
    {
        private RBContext db = context;
        private LanguageRepository languageRepository;
        private GuestCommentsRepository guestCommentsRepository;
        private GuestPaymentMethodRepository guestPaymentMethodRepository;
        private EmergencyContactPersonRepository emergencyContactPersonRepository;
        private ChatRepository chatRepository;
        private CountryRepository countryRepository;
        private BookingRepository bookingRepository;
        private OfferedAmenitiesRepository offeredAmenitiesRepository;
        private PictureRepository pictureRepository;
        private ProfileRepository profileRepository;
        private LocationRepository  locationRepository;
        private HouseRepository houseRepository;
        private SportRepository sportRepository;
        private RentalApartmentRepository rentalApartmentRepository;
        private UserRepository userRepository;
        private CommentsAboutGuestRepository commentsAboutGuestRepository;
        private WishlistRepository wishlistRepository;
        public IRepositoryOfAll<Wishlist> Wishlist
        {
            get
            {
                if (wishlistRepository == null)
                    wishlistRepository = new WishlistRepository(db);
                return wishlistRepository;
            }
        }
        public IRepositoryOfAll<CommentsAboutGuest> CommentsAboutGuest
        {
            get
            {
                if (commentsAboutGuestRepository == null)
                    commentsAboutGuestRepository = new CommentsAboutGuestRepository(db);
                return commentsAboutGuestRepository;
            }
        }
        public IRepositoryOfAll<User> User
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepositoryOfAll<RentalApartment> RentalApartment
        {
            get
            {
                if (rentalApartmentRepository == null)
                    rentalApartmentRepository = new RentalApartmentRepository(db);
                return rentalApartmentRepository;
            }
        }
        public IRepositoryOfAll<Sport> Sport
        {
            get
            {
                if (sportRepository == null)
                    sportRepository = new SportRepository(db);
                return sportRepository;
            }
        }
        public IRepositoryOfAll<House> House
        {
            get
            {
                if (houseRepository == null)
                    houseRepository = new HouseRepository(db);
                return houseRepository;
            }
        }
        public IRepositoryOfAll<Location> Location
        {
            get
            {
                if (locationRepository == null)
                    locationRepository = new LocationRepository(db);
                return locationRepository;
            }
        }
        public IRepositoryOfAll<Profile> Profile
        {
            get
            {
                if (profileRepository == null)
                    profileRepository = new ProfileRepository(db);
                return profileRepository;
            }
        }
        public IRepositoryOfAll<Picture> Picture
        {
            get
            {
                if (pictureRepository == null)
                    pictureRepository = new PictureRepository(db);
                return pictureRepository;
            }
        }
        public IRepositoryOfAll<OfferedAmenities> OfferedAmenities
        {
            get
            {
                if (offeredAmenitiesRepository == null)
                    offeredAmenitiesRepository = new OfferedAmenitiesRepository(db);
                return offeredAmenitiesRepository;
            }
        }
        public IRepositoryOfAll<Chat> Chat
        {
            get
            {
                if (chatRepository == null)
                    chatRepository = new ChatRepository(db);
                return chatRepository;
            }
        }
        public IRepositoryOfAll<Booking> Booking
        {
            get
            {
                if (bookingRepository == null)
                    bookingRepository = new BookingRepository(db);
                return bookingRepository;
            }
        }
        public IRepositoryOfAll<Country> Country
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new CountryRepository(db);
                return countryRepository;
            }
        }
        public IRepositoryOfAll<GuestComments> GuestComments
        {
            get
            {
                if (guestCommentsRepository == null)
                    guestCommentsRepository = new GuestCommentsRepository(db);
                return guestCommentsRepository;
            }
        }
        public IRepositoryOfAll<Language> Languages
        {
            get
            {
                if (languageRepository == null)
                    languageRepository = new LanguageRepository(db);
                return languageRepository;
            }
        }
        public IRepositoryOfAll<EmergencyContactPerson> EmergencyContactPerson
        {
            get
            {
                if (emergencyContactPersonRepository == null)
                    emergencyContactPersonRepository = new EmergencyContactPersonRepository(db);
                return emergencyContactPersonRepository;
            }
        }
        public IRepositoryOfAll<GuestPaymentMethod> GuestPaymentMethod
        {
            get
            {
                if (guestPaymentMethodRepository == null)
                    guestPaymentMethodRepository = new GuestPaymentMethodRepository(db);
                return guestPaymentMethodRepository;
            }
        }
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
