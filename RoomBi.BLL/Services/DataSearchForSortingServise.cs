using AutoMapper;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi.DAL.Entities;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Services
{
    public class DataSearchForSortingServise(IUnitOfWork uow) :
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage>

    {
        IUnitOfWork Database { get; set; } = uow;

        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> DateBookingSearch(DateBooking booking, ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO)
        {
            DateTime start = new(booking.Start!.Year, booking.Start!.Month, booking.Start!.Day);
            DateTime end = new(booking.End!.Year, booking.End!.Month, booking.End!.Day);
            IEnumerable<RentalApartment> rentalApartments;
            ICollection<RentalApartmentDTOForStartPage> rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            if (rentalApartmentDTO == null)
            {
                rentalApartments = await Database.SearchRentalApartment.GetAllMinForSearch();
                foreach (var item in rentalApartments)
                {
                    var apartment = await Database.SearchRentalApartment.GetApartmentsByDateBooking(start, end, item.Id);
                    if (apartment != null)
                    {
                        rentalApartmentResult.Add(NewRentalApartment(apartment));
                    }
                }
            }
            else
            {
                foreach (var item in rentalApartmentDTO)
                {
                    var apartment = await Database.SearchRentalApartment.GetApartmentsByDateBooking(start, end, item.Id);
                    if (apartment != null)
                        rentalApartmentResult.Add(NewRentalApartment(apartment));
                }
            }
            return rentalApartmentResult;
        }

        public static RentalApartmentDTOForStartPage NewRentalApartment(RentalApartment apartment)
        {
            var rentalApartmentTemp = new RentalApartmentDTOForStartPage
            {
                Id = apartment.Id,
                Title = apartment.Title,
                IngMap = apartment.IngMap,
                LatMap = apartment.LatMap,
                PricePerNight = apartment.PricePerNight,
                ObjectRating = apartment.ObjectRating,
                Country = apartment.Country?.Name,
                //Wish = await Database.GetItemWishlist.CheckIfWishlistItemExists(idUser, apartment.Id),
                //Location = apartment.Location?.Name,
                //House = apartment.House?.Name,
                //Sport = apartment.Sport?.Name,
                Pictures = apartment.Pictures,

            };
            rentalApartmentTemp.Country += ", " + apartment.Address;
            rentalApartmentTemp.BookingFree = FormatDate(apartment);
            return rentalApartmentTemp;
        }
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllByType(string type, string name)
        {
            ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();
            try
            {
                if (type != null || type != "")
                {
                    switch (type)
                    {
                        case "country":
                            var rentalApartments = await Database.SearchRentalApartment.GetApartmentsByCountry(name);
                            foreach (var item in rentalApartments)
                            {
                                rentalApartmentDTO.Add(NewRentalApartment(item));
                            }
                            return rentalApartmentDTO;
                        case "continent":
                            rentalApartments = await Database.SearchRentalApartment.GetApartmentsByContinent(name);
                            foreach (var item in rentalApartments)
                            {
                                rentalApartmentDTO.Add(NewRentalApartment(item));
                            }
                            return rentalApartmentDTO;
                        case "city":
                            rentalApartments = await Database.SearchRentalApartment.GetApartmentsByCity(name);
                            foreach (var item in rentalApartments)
                            {
                                rentalApartmentDTO.Add(NewRentalApartment(item));
                            }
                            return rentalApartmentDTO;
                        default:
                            throw new Exception("Не корректный type.");
                    }
                }
            }
            catch (Exception)
            {
                return rentalApartmentDTO;
            }
            return rentalApartmentDTO;
        }
        public static string FormatDate(RentalApartment rentalApartment)
        {
            if (rentalApartment.Booking == null || rentalApartment.Booking.Count == 0)
            {
                DateTime date = DateTime.Now;
                DateTime newDate = date.AddDays(5);
                string formattedDate = date.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                        " - " +
                                        newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                return formattedDate;
            }
            var bookings = rentalApartment.Booking.OrderBy(b => b.CheckOutDate).ToList();
            DateTime datenow = DateTime.Now;
            DateTime first = bookings.First().CheckInDate;
            TimeSpan difference1 = first - datenow;
            if (difference1.Days >= 5)
            {
                DateTime newDate = datenow.AddDays(5);
                string formattedDate = datenow.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                        " - " +
                                        newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                return formattedDate;
            }
            DateTime lastCheckOutDate = bookings.First().CheckOutDate;
            foreach (var booking in bookings.Skip(1))
            {
                DateTime nextCheckInDate = booking.CheckInDate;
                TimeSpan difference = nextCheckInDate - lastCheckOutDate;
                if (difference.Days >= 5)
                {
                    DateTime newDate = lastCheckOutDate.AddDays(5);
                    string formattedDate = lastCheckOutDate.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                            " - " +
                                            newDate.ToString("dd MMM", new CultureInfo("uk-UA"));
                    return formattedDate;
                }
                lastCheckOutDate = booking.CheckOutDate;
            }
            DateTime newDate1 = lastCheckOutDate.AddDays(5);
            string formattedDate1 = lastCheckOutDate.ToString("dd MMM", new CultureInfo("uk-UA")) +
                                    " - " +
                                    newDate1.ToString("dd MMM", new CultureInfo("uk-UA"));
            return formattedDate1;

        }

        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllByNumberOfGuests(int why, ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO)
        {
            ICollection<RentalApartmentDTOForStartPage> rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            var rentalApartments = await Database.SearchRentalApartment.GetApartmentsByNumberOfGuests(why);
            if (rentalApartmentDTO == null)
            {
                
                foreach (var item in rentalApartments)
                {
                    rentalApartmentResult.Add(NewRentalApartment(item));
                }
                return rentalApartmentResult;
            }
            else
            {
                var filteredApartments = rentalApartments.Where(apartment => apartment.NumberOfGuests == why).ToList();
                var apartmentIds = filteredApartments.Select(apartment => apartment.Id).ToList();
                var sortedResult = rentalApartmentDTO.Where(result => apartmentIds.Contains(result.Id)).ToList();
                return sortedResult;
            }
        }
    }
}
