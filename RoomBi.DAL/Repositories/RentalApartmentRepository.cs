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
    public class RentalApartmentRepository(RBContext context) : IRepositoryOfAll<RentalApartment>
    {
        private readonly RBContext context = context;
        public async Task<IEnumerable<RentalApartment>> GetAll()
        {
            
            var temp = await context.RentalApartments
           .Include(ra => ra.Country)
           //.Include(ra => ra.Location)
           //.Include(ra => ra.House)
           //.Include(ra => ra.Sport)
           //.Include(ra => ra.OfferedAmenities)
           .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var bookings = bookingRepository.GetBookingsByApartmentId(i + 1);
                temp[i].Booking = (ICollection<Booking>)bookings;
                var pictures = pictureRepository.GetPicturesByApartmentId(i + 1);
                temp[i].Booking = (ICollection<Booking>)bookings;
            }
            return temp;
        }
        public async Task<RentalApartment> Get(int id)
        {
            var bookingsRepository = new BookingRepository(context);
            var booking = bookingsRepository.GetBookingsByApartmentId(id);

            var pictureRepository = new PictureRepository(context);
            var pictures = pictureRepository.GetPicturesByApartmentId(id);

            var chatRepository = new ChatRepository(context);
            var chats = chatRepository.GetChatsByApartmentId(id); 

            var guestCommentsRepository = new GuestCommentsRepository(context);
            var guestComments = guestCommentsRepository.GetGuestCommentsByApartmentId(id);

            var rentalApartment = await context.RentalApartments.Include(r => r.Pictures)
                                                                .Include(r => r.Booking)
                                                                .Include(r => r.Chats)
                                                                .Include(r => r.GuestComments)
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
    }
}

