using RoomBi.DAL.Entities;
using RoomBi.DAL.Repositories;


namespace RoomBi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryOfAll<Language> Languages { get; }
        IRepositoryOfAll<GuestComments> GuestComments { get; }
        IRepositoryOfAll<GuestPaymentMethod> GuestPaymentMethod { get; }
        IRepositoryOfAll<EmergencyContactPerson> EmergencyContactPerson { get; }
        IRepositoryOfAll<Chat> Chat { get; }
        IRepositoryOfAll<Country> Country { get; }
        IRepositoryOfAll<Сontinent> Сontinent { get; }
        IRepositoryOfAll<Booking> Booking { get; }
       
        IRepositoryOfAll<Picture> Picture { get; }
        IRepositoryOfAll<Profile> Profile { get; }
        IRepositoryOfAll<House> House { get; }
        IRepositoryOfAll<Location> Location { get; }
        IRepositoryOfAll<Sport> Sport { get; }
        IRepositoryOfAll<User> User { get; }
        IRepositoryOfAll<CommentsAboutGuest> CommentsAboutGuest { get; }
        IRepositoryOfAll<Wishlist> Wishlist { get; }

        IRepositoryOfAll<RentalApartment> RentalApartment { get; }
        IRepositoryOfAll<OfferedAmenities> OfferedAmenities { get; }
        IRepositoryGet24<RentalApartment> Apartment24 { get; }
        IRepositorySearch<RentalApartment> SearchRentalApartment { get; }
       
        IRepositoryGetAllByID<Booking> Booking2 { get; }
      
       
       
        IRepositoryGetWishlictitem<Wishlist> GetItemWishlist { get; }
        IRepositoryGetAllByID<Wishlist> RepositoryGetAllByID { get; }

        IRepositoryGetEmailAndPassword<User> UserGetEmailAndPassword { get; }
        IRepositoryGetName<Language> LanguageGetName { get; }
        IRepositoryGetName<Country> CountryGetName { get; }
        IRepositoryGetName<Сontinent> СontinentGetName { get; }
        IRepositoryForChat<Chat> GetAllChat { get; }

        IRepositoryGetName<Sport> SportRepositoryGetName { get; }
        IRepositoryGetName<Location> LocationRepositoryGetName { get; }
        IRepositoryGetName<House> HouseRepositoryGetName { get; }
        IRepositoryGetName<RentalApartment> RentalApartmentRepositoryGetName { get; }
        Task Save();
    }
}
