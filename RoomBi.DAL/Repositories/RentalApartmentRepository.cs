﻿using Azure;
using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class RentalApartmentRepository
        : IRepositoryOfAll<RentalApartment>, IRepositoryGet24<RentalApartment>
    {
        private readonly RBContext context;
        //private readonly BookingRepository bookingRepository;
        //private readonly PictureRepository pictureRepository;

        public RentalApartmentRepository(RBContext context/*, BookingRepository bookingRepository, PictureRepository pictureRepository*/)
        {
            this.context = context;
            //this.bookingRepository = bookingRepository;
            //this.pictureRepository = pictureRepository;
        }

       
        public async Task<RentalApartment> Get(int id)
        {
            var bookingsRepository = new BookingRepository(context);
            var booking = bookingsRepository.ByApartmentId(id);

            var pictureRepository = new PictureRepository(context);
            var pictures = pictureRepository.ByApartmentId(id);

            var chatRepository = new ChatRepository(context);
            var chats = chatRepository.GetChatsByApartmentId(id);

            var guestCommentsRepository = new GuestCommentsRepository(context);
            var guestComments = guestCommentsRepository.GetGuestCommentsByApartmentId(id);

            var rentalApartment = await context.RentalApartments/*.Include(r => r.Pictures)*/
                                                                //.Include(r => r.Booking)
                                                                //.Include(r => r.Chats)
                                                                //.Include(r => r.GuestComments)
                                                                .Include(r => r.Location)
                                                                .Include(r => r.House)
                                                                .Include(r => r.Sport)
                                                                .Include(r => r.Country)
                                                                .Include(r => r.User)
                                                                .Include(r => r.OfferedAmenities)
                                                                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentalApartment != null)
            {
                rentalApartment.Pictures = (ICollection<Picture>)pictures;
                rentalApartment.Booking = (ICollection<Booking>)booking;
                rentalApartment.Chats = (ICollection<Chat>)chats;
                rentalApartment.GuestComments = (ICollection<GuestComments>)guestComments;
            }
            return rentalApartment;
        }
        public async Task Create(RentalApartment item)
        {
            await context.RentalApartments.AddAsync(item);
        }
        public async Task Update(RentalApartment item)
        {
              context.RentalApartments.Update(item);
        }
        public async Task Delete(int id)
        {
            RentalApartment? item = await context.RentalApartments.FindAsync(id);
            if (item != null)
                context.RentalApartments.Remove(item);
        }
        public async Task<IEnumerable<RentalApartment>> Get24(int page, int pageSize)
        {
            var temp = await context.RentalApartments
                .Include(ra => ra.Country)
                .Include(ra => ra.Location)
                .Include(ra => ra.House)
                .Include(ra => ra.Sport)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var apartment = temp[i];
                var bookings = await bookingRepository.ByApartmentId(apartment.Id);
                var pictures = await pictureRepository.ByApartmentId(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }

            return temp;
        }
        public async Task<IEnumerable<RentalApartment>> GetAll()
        {

            var temp = await context.RentalApartments
                 .Include(ra => ra.Country)
                 .Include(ra => ra.Location)
                 .Include(ra => ra.House)
                 .Include(ra => ra.Sport)
                 .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var apartment = temp[i];
                var bookings = await bookingRepository.ByApartmentId(apartment.Id);
                var pictures = await pictureRepository.ByApartmentId(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }

            return temp;
        }

    }
  
}


