﻿using RoomBi.DAL.Entities;
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
        IRepositoryLanguage<Language> Language { get; }
        IRepositoryOfAll<GuestComments> GuestComments{ get; }
        IRepositoryOfAll<GuestPaymentMethod> GuestPaymentMethod { get; }
        IRepositoryOfAll<EmergencyContactPerson> EmergencyContactPerson { get; }
        IRepositoryOfAll<Chat> Chat { get; }
        IRepositoryOfAll<Country> Country { get; }
        IRepositoryCountry<Country> Countries { get; }
        IRepositoryOfAll<Booking> Booking { get; }
        IRepositoryOfAll<OfferedAmenities> OfferedAmenities { get; }
        IRepositoryOfAll<Picture> Picture { get; }
        IRepositoryOfAll<Profile> Profile { get; }
        IRepositoryOfAll<House> House { get; }
        IRepositoryOfAll<Location> Location { get; }
        IRepositoryOfAll<Sport> Sport { get; }
        IRepositoryOfAll<RentalApartment> RentalApartment { get; }
        IRepositoryGet24<RentalApartment> Apartment24 { get; }
        IRepositoryOfAll<User> User { get; }
        IRepositoryOfAll<CommentsAboutGuest> CommentsAboutGuest { get; }
        IRepositoryOfAll<Wishlist> Wishlist { get; }


        Task Save();
    }
}
