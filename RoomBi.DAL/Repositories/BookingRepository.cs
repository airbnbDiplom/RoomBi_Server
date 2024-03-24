using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class BookingRepository(RBContext context) : IRepositoryOfAll<Booking>, IRepositoryForApartment<Booking>
    {
        private readonly RBContext context = context;
        public async Task<IEnumerable<Booking>> ByApartmentId(int apartmentId)
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
            //return await context.Bookings.FindAsync(id);
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
