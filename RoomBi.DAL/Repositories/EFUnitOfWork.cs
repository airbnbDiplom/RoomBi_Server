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

    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly RBContext _context;

        public EFUnitOfWork(RBContext context)
        {
            _context = context;
        }
    
        private LanguageRepository _languageRepository;
        public IRepositoryOfAll<Language> Languages => _languageRepository ??= new LanguageRepository(_context);

        private GuestCommentsRepository _guestCommentsRepository;
        public IRepositoryOfAll<GuestComments> GuestComments => _guestCommentsRepository ??= new GuestCommentsRepository(_context);

        private GuestPaymentMethodRepository _guestPaymentMethodRepository;
        public IRepositoryOfAll<GuestPaymentMethod> GuestPaymentMethod => _guestPaymentMethodRepository ??= new GuestPaymentMethodRepository(_context);

        private EmergencyContactPersonRepository _emergencyContactPersonRepository;
        public IRepositoryOfAll<EmergencyContactPerson> EmergencyContactPerson => _emergencyContactPersonRepository ??= new EmergencyContactPersonRepository(_context);

        private ChatRepository _chatRepository;
        public IRepositoryOfAll<Chat> Chat => _chatRepository ??= new ChatRepository(_context);
     

        private СontinentRepository _continentRepository;
        public IRepositoryOfAll<Сontinent> Сontinent => _continentRepository ??= new СontinentRepository(_context);

        private CountryRepository _countryRepository;
        public IRepositoryOfAll<Country> Country => _countryRepository ??= new CountryRepository(_context);

        private BookingRepository _bookingRepository;
        public IRepositoryOfAll<Booking> Booking => _bookingRepository ??= new BookingRepository(_context);
        private BookingRepository _bookingRepository2;
        public IRepositoryGetAllByID<Booking> Booking2 => _bookingRepository2 ??= new BookingRepository(_context);
        private OfferedAmenitiesRepository _offeredAmenitiesRepository;
        public IRepositoryOfAll<OfferedAmenities> OfferedAmenities => _offeredAmenitiesRepository ??= new OfferedAmenitiesRepository(_context);

        private PictureRepository _pictureRepository;
        public IRepositoryOfAll<Picture> Picture => _pictureRepository ??= new PictureRepository(_context);

        private ProfileRepository _profileRepository;
        public IRepositoryOfAll<Profile> Profile => _profileRepository ??= new ProfileRepository(_context);

        private LocationRepository _locationRepository;
        public IRepositoryOfAll<Location> Location => _locationRepository ??= new LocationRepository(_context);

        private HouseRepository _houseRepository;
        public IRepositoryOfAll<House> House => _houseRepository ??= new HouseRepository(_context);

        private SportRepository _sportRepository;
        public IRepositoryOfAll<Sport> Sport => _sportRepository ??= new SportRepository(_context);

        private UserRepository _userRepository;
        public IRepositoryOfAll<User> User => _userRepository ??= new UserRepository(_context);

        private CommentsAboutGuestRepository _commentsAboutGuestRepository;
        public IRepositoryOfAll<CommentsAboutGuest> CommentsAboutGuest => _commentsAboutGuestRepository ??= new CommentsAboutGuestRepository(_context);

        private WishlistRepository _wishlistRepository;
        public IRepositoryOfAll<Wishlist> Wishlist => _wishlistRepository ??= new WishlistRepository(_context);

        private RentalApartmentRepository _rentalApartmentRepository;
        public IRepositoryOfAll<RentalApartment> RentalApartment => _rentalApartmentRepository ??= new RentalApartmentRepository(_context/*, _bookingRepository, _pictureRepository*/);


        private WishlistRepository _wishlistItemRepository;
        public IRepositoryGetWishlictitem<Wishlist> GetItemWishlist => _wishlistItemRepository ??= new WishlistRepository(_context);

        private RentalApartmentRepository _apartment24Repository;
        public IRepositoryGet24<RentalApartment> Apartment24 => _apartment24Repository ??= new RentalApartmentRepository(_context);
        private UserRepository _userRepository2;
        public IRepositoryGetEmailAndPassword<User> UserGetEmailAndPassword => _userRepository2 ??= new UserRepository(_context);

        private LanguageRepository _languageRepository2;
        public IRepositoryGetName<Language> LanguageGetName => _languageRepository2 ??= new LanguageRepository(_context);

        private CountryRepository _countryRepository2;
        public IRepositoryGetName<Country> CountryGetName => _countryRepository2 ??= new CountryRepository(_context);

        private СontinentRepository _continentRepository2;
        public IRepositoryGetName<Сontinent> СontinentGetName => _continentRepository2 ??= new СontinentRepository(_context);
        
        private RentalApartmentRepository _rentalApartmentRepository2;
        public IRepositorySearch<RentalApartment> SearchRentalApartment => _rentalApartmentRepository2 ??= new RentalApartmentRepository(_context);

        private ChatRepository _chatRepository2;
        public IRepositoryForChat<Chat> GetAllChat => _chatRepository2 ??= new ChatRepository(_context);


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
