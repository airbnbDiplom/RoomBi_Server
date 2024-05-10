using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace RoomBi.BLL.Services
{

    public class BookingService(IUnitOfWork uow) : IServiceBooking<BookingDTO>,
        IServiceGetAllIdUser<MessageObj>, IServiceGetAllIdUser<BookingDTOWithFoto>
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
            await Database.Booking.Create(booking);
            var guestPaymentMethodp = new GuestPaymentMethod
            {
                CardNumber = bookingDto.Payment.CardNumber,
                ExpirationDate = bookingDto.Payment.ExpirationDate,
                CVV = bookingDto.Payment.CVV,
                CardType = bookingDto.Payment.CardType,
                IdUser = booking.OwnerId
            };
            await Database.GuestPaymentMethod.Create(guestPaymentMethodp);
            await Database.Save();
        }
        public async Task CreateBookingWithChat(BookingDTO bookingDto)
        {
            var booking = new Booking
            {
                OwnerId = bookingDto.OwnerId,
                ApartmentId = bookingDto.ApartmentId,
                CheckInDate = new DateTime(bookingDto.CheckInDate.Year, bookingDto.CheckInDate.Month, bookingDto.CheckInDate.Day),
                CheckOutDate = new DateTime(bookingDto.CheckOutDate.Year, bookingDto.CheckOutDate.Month, bookingDto.CheckOutDate.Day),
                TotalPrice = bookingDto.TotalPrice,
                PaymentStatus = false

            };
            await Database.Booking.Create(booking);
            await Database.Save();
        }

        public async Task<List<MessageObj>> GetAllObj(int fromId)
        {
            var temp = await Database.GetAllChat.GetAllChat(fromId);
            var messageObjs = new List<MessageObj>();
            for (int i = 0; i < temp.Count; i++)
            {
                List<Chat>? chatGroup = temp[i];
                var from = await Database.User.Get(chatGroup[0].From);
                var to = await Database.User.Get(chatGroup[0].To);
                var apartment = await Database.RentalApartment.Get(chatGroup[0].RentalApartmentId);
                var messageObj = new MessageObj
                {
                    FotoFrom = from.ProfilePicture,
                    FotoTo = to.ProfilePicture,
                    FotoApartment = apartment.Pictures.FirstOrDefault()?.PictureUrl,
                    NameApartment = apartment.Title,
                    NameFrom = from.Name,
                    NameTo = to.Name,
                    Booking = await Database.Booking.Get(apartment.Id),
                    Message = chatGroup.Select(chat => new ChatForApartmentPageDTO
                    {
                        Id = chat.Id,
                        Comment = chat.Comment,
                        DateTime = chat.DateTime,
                        RentalApartmentId = chat.RentalApartmentId,
                        FromId = chat.From,
                        ToId = chat.To
                    }).ToList()
                };
                messageObjs.Add(messageObj);

            }
            return messageObjs;
        }

        async Task<List<BookingDTOWithFoto>> IServiceGetAllIdUser<BookingDTOWithFoto>.GetAllObj(int IdUser)
        {
            var booking = await Database.Booking.GetAll();
            var bookingList = new List<BookingDTOWithFoto>();
            foreach (var item in booking)
            {
                if (item.OwnerId == IdUser)
                {
                    var apartment = await Database.RentalApartment.Get(item.ApartmentId);

                    BookingDTOWithFoto bookingDTOWithFoto = new()
                    {
                        ApartmentId = item.ApartmentId,
                        TitleApartment = apartment.Title,
                        CheckInDate = item.CheckInDate,
                        CheckOutDate = item.CheckOutDate,
                        Pictures = apartment.Pictures
                    };
                    if(apartment.GuestComments != null)
                    {
                        bookingDTOWithFoto.Comment = HasCommentForUser(apartment.GuestComments, IdUser);
                    }
                    bookingList.Add(bookingDTOWithFoto);
                }
               

            }
            return bookingList;
        }

        public bool HasCommentForUser(ICollection<GuestComments> guestComments, int userId)
        {
            return guestComments.Any(comment => comment.GuestIdUser == userId);
        }





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
