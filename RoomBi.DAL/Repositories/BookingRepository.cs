﻿using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;


namespace RoomBi.DAL.Repositories
{
    public class BookingRepository(RBContext context) : IRepositoryOfAll<Booking>,
        IRepositoryGetAllByID<Booking>
    {
        private readonly RBContext context = context;
        public async Task<IEnumerable<Booking>> GetAllById(int apartmentId)
        {
            return await context.Bookings
                .Where(booking => booking.ApartmentId == apartmentId)
                .OrderBy(booking => booking.CheckInDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await context.Bookings.ToListAsync();
        }
        public async Task<Booking> Get(int id)
        {

            return await context.Bookings.FirstOrDefaultAsync(m => m.ApartmentId == id);
        }
        public async Task Create(Booking item)
        {

            await context.Bookings.AddAsync(item);
        }
        public async Task Update(Booking item)
        {
            context.Bookings.Update(item);
        }
        public async Task Delete(int id)
        {
            Booking? item = await context.Bookings.FindAsync(id);
            if (item != null)
                context.Bookings.Remove(item);
        }

        internal Task GetBookingsByApartmentIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
