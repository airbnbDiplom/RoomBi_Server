using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class BookingService : IServiceBooking<DateBooking>
    {
        IUnitOfWork Database { get; set; }

        public BookingService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task CreateBooking(DateBooking item)
        {
            //var booking = new Booking
            //{
                //Id = bookingDto.Id,
                //OwnerId = bookingDto.OwnerId,
                //ApartmentId = bookingDto.ApartmentId,
                //CheckInDate = bookingDto.CheckInDate,
                //CheckOutDate = bookingDto.CheckOutDate,
                //NumberOfGuests = bookingDto.NumberOfGuests,
                //TotalPrice = bookingDto.TotalPrice,
                //PaymentStatus = bookingDto.PaymentStatus

            //};
            //await Database.Booking.Create(booking);
            //await Database.Save();
        }
        //public async Task Create(DateBooking bookingDto)
        //{
        //    var booking = new Booking
        //    {
        //        Id = bookingDto.Id,
        //        OwnerId = bookingDto.OwnerId,
        //        ApartmentId = bookingDto.ApartmentId,
        //        CheckInDate = bookingDto.CheckInDate,
        //        CheckOutDate = bookingDto.CheckOutDate,
        //        NumberOfGuests = bookingDto.NumberOfGuests,
        //        TotalPrice = bookingDto.TotalPrice,
        //        PaymentStatus = bookingDto.PaymentStatus

        //    };
        //    await Database.Booking.Create(booking);
        //    await Database.Save();
        //}

        //public async Task Update(DateBooking bookingDto)
        //{
        //    var booking = new Booking
        //    {
        //Id = bookingDto.Id,
        //OwnerId = bookingDto.OwnerId,
        //ApartmentId = bookingDto.ApartmentId,
        //CheckInDate = bookingDto.CheckInDate,
        //CheckOutDate = bookingDto.CheckOutDate,
        //NumberOfGuests = bookingDto.NumberOfGuests,
        //TotalPrice = bookingDto.TotalPrice,
        //PaymentStatus = bookingDto.PaymentStatus

        //    };
        //    await Database.Booking.Update(booking);
        //    await Database.Save();
        //}

        //public async Task Delete(int id)
        //{
        //    await Database.Booking.Delete(id);
        //    await Database.Save();
        //}



        //public async Task<DateBooking> Get(int id)
        //{
        //    var booking = await Database.Booking.Get(id);
        //    if (booking == null)
        //        throw new ValidationException("Wrong booking!", "");
        //    return new DateBooking
        //    {
        //        //Id = booking.Id,
        //        //OwnerId = booking.OwnerId,
        //        //ApartmentId = booking.ApartmentId,
        //        //CheckInDate = booking.CheckInDate,
        //        //CheckOutDate = booking.CheckOutDate,
        //        //NumberOfGuests = booking.NumberOfGuests,
        //        //TotalPrice = booking.TotalPrice,
        //        //PaymentStatus = booking.PaymentStatus
        //    };
        //}

        //public async Task<IEnumerable<DateBooking>> GetAll()
        //{
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Booking, DateBooking>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Booking>, IEnumerable<DateBooking>>(await Database.Booking.GetAll());
        //}

    }
}
