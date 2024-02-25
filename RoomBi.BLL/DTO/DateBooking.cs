using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{

    public class DateBi
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        // Конструктор класса DateBi
        public DateBi(DateTime dateTime)
        {
            Day = dateTime.Day;
            Month = dateTime.Month;
            Year = dateTime.Year;
        }
        public DateBi()
        {
        }
    }

    public class DateBooking
    {
        public DateBi? Start { get; set; }
        public DateBi? End { get; set; }

        public DateBooking(DateTime start, DateTime end)
        {
            Start = new DateBi(start);
            End = new DateBi(end);
        }
        public DateBooking()
        {
        }

    }
    public class BookingDTO
    {
        public int OwnerId { get; set; }
        public int ApartmentId { get; set; }
        public DateBi? CheckInDate { get; set; }
        public DateBi? CheckOutDate { get; set; }
        public double TotalPrice { get; set; }
        public Payment? Payment { get; set; }

    }
}
