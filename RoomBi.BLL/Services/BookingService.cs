using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;

namespace RoomBi.BLL.Services
{

    public class BookingService(IUnitOfWork uow) : IServiceBooking<BookingDTO>
    {
        IUnitOfWork Database { get; set; } = uow;

        public async Task CreateBooking(BookingDTO bookingDto)
        {
            var booking = new Booking
            {
                OwnerId = bookingDto.OwnerId,
                ApartmentId = bookingDto.ApartmentId,
                CheckInDate = new DateTime(bookingDto.CheckInDate.Year, bookingDto.CheckInDate.Month, bookingDto.CheckInDate.Day),
                CheckOutDate = new DateTime(bookingDto.CheckOutDate.Year, bookingDto.CheckOutDate.Month, bookingDto.CheckOutDate.Day),
                TotalPrice = bookingDto.TotalPrice,
                PaymentStatus = true

            };
            Console.WriteLine("CheckInDate: " + booking.CheckInDate.ToString("yyyy-MM-dd"));
            await Database.Booking.Create(booking);
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
