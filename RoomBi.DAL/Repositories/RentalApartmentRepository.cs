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

            return await context.RentalApartments.FirstOrDefaultAsync(m => m.Id == id);
            //return await context.RentalApartments.FindAsync(id);
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

