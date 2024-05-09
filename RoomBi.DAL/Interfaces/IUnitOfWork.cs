using RoomBi.DAL.Entities;
using RoomBi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryOfAll<Language> Languages { get; }
        IRepositoryOfAll<GuestComments> GuestComments{ get; }
        IRepositoryOfAll<GuestPaymentMethod> GuestPaymentMethod { get; }
        IRepositoryOfAll<EmergencyContactPerson> EmergencyContactPerson { get; }
        IRepositoryOfAll<Chat> Chat { get; }
     
        IRepositoryOfAll<Country> Country { get; }
        IRepositoryOfAll<Сontinent> Сontinent { get; }
        IRepositoryOfAll<Booking> Booking { get; }
        IRepositoryGetAllByID<Booking> Booking2 { get; }
        IRepositoryOfAll<OfferedAmenities> OfferedAmenities { get; }
        IRepositoryOfAll<Picture> Picture { get; }
        IRepositoryOfAll<Profile> Profile { get; }
        IRepositoryOfAll<House> House { get; }
        IRepositoryOfAll<Location> Location { get; }
        IRepositoryOfAll<Sport> Sport { get; }
        IRepositoryOfAll<RentalApartment> RentalApartment { get; }
        IRepositoryOfAll<User> User { get; }
        IRepositoryOfAll<CommentsAboutGuest> CommentsAboutGuest { get; }
        IRepositoryOfAll<Wishlist> Wishlist { get; }
        IRepositoryGet24<RentalApartment> Apartment24 { get; }
        IRepositoryGetWishlictitem<Wishlist> GetItemWishlist { get; }
        IRepositoryGetEmailAndPassword<User> UserGetEmailAndPassword { get; }
        IRepositoryGetName<Language> LanguageGetName { get; }
        IRepositoryGetName<Country> CountryGetName { get; }
        IRepositoryGetName<Сontinent> СontinentGetName { get; }
        IRepositorySearch<RentalApartment> SearchRentalApartment { get; }
        IRepositoryForChat<Chat> GetAllChat { get; }
        Task Save();
    }
}
