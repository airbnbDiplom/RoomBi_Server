using AutoMapper;
using Azure.Core;
using RoomBi.BLL.DTO;
using RoomBi.BLL.DTO.New;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi.DAL.EF;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RoomBi.BLL.Services
{
    public class DataSearchForSortingServise(IUnitOfWork uow) :
        IServiceDataSearchForSorting<RentalApartment>,
        IServiceForSorting<RentalApartmentDTOForStartPage>,
        IServiceForSorting<RentalApartmentDTOWithBooking>
    {
        IUnitOfWork Database { get; set; } = uow;
        public async Task<IEnumerable<RentalApartment>> GetAllByType(Where where)
        {
            IEnumerable<RentalApartment> rentalApartment;
            try
            {
                switch (where.Type)
                {
                    case "country":
                        rentalApartment = await Database.SearchRentalApartment.GetApartmentsByCountryCode(where.CountryCode);
                        return rentalApartment;
                    default:
                        rentalApartment = await Database.SearchRentalApartment.GetApartmentsByCity(where.PlaceId);
                        return rentalApartment;
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<RentalApartment>();
            }
        }


        public async Task<IEnumerable<RentalApartment>> DateBookingSearch()
        {
            IEnumerable <RentalApartment> rentalApartments = await Database.RentalApartment.GetAll();

            //if (rentalApartment == null)
            //{
            //    IEnumerable<RentalApartment> rentalApartments = await Database.SearchRentalApartment.GetAllMinForSearch();

            //    foreach (var item in rentalApartments)
            //    {
            //        var apartment = await Database.SearchRentalApartment.GetApartmentsByDateBooking(booking.Start, booking.End, item.Id);
            //        if (apartment != null)
            //        {
            //            rentalApartmentResult.Add(apartment);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var item in rentalApartment)
            //    {
            //        var apartment = await Database.SearchRentalApartment.GetApartmentsByDateBooking(booking.Start, booking.End, item.Id);
            //        if (apartment != null)
            //            rentalApartmentResult.Add(apartment);
            //    }
            //}
            return rentalApartments;
        }
        public async Task<IEnumerable<RentalApartment>> GetAllByNumberOfGuests(int? why, IEnumerable<RentalApartment> rentalApartment)
        {

            var rentalApartments = await Database.SearchRentalApartment.GetApartmentsByNumberOfGuests(why);
            if (rentalApartment == null)
            {
                return rentalApartments;
            }
            else
            {
                var filteredApartments = rentalApartments.Where(apartment => apartment.NumberOfGuests >= why).ToList();
                var apartmentIds = filteredApartments.Select(apartment => apartment.Id).ToList();
                var sortedResult = rentalApartment.Where(result => apartmentIds.Contains(result.Id)).ToList();
                return sortedResult;
            }
        }
        public async Task<RentalApartmentDTOForStartPage> NewRentalApartment(RentalApartment apartment)
        {
            Country country = await Database.Country.Get(apartment.CountryId);
            var rentalApartmentTemp = new RentalApartmentDTOForStartPage
            {
                Id = apartment.Id,
                Title = apartment.Title,
                IngMap = apartment.IngMap,
                LatMap = apartment.LatMap,
                PricePerNight = apartment.PricePerNight,
                ObjectRating = apartment.ObjectRating,
                Country = country.Name,
                Pictures = apartment.Pictures
            };
            rentalApartmentTemp.Country += ", " + apartment.Address;
            rentalApartmentTemp.BookingFree = FormatDate(apartment);
            return rentalApartmentTemp;
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
        public async Task<IEnumerable<RentalApartment>> GetAllByFilter(Filter filter)
        {
            if (filter.TypeOfHousing != null && filter.TypeOfHousing.Count() == 0) filter.TypeOfHousing = null;
            if (filter.OfferedAmenitiesDTO != null && filter.OfferedAmenitiesDTO.Count() == 0) filter.OfferedAmenitiesDTO = null;
            if (filter.HostsLanguage != null && filter.HostsLanguage.Count() == 0) filter.HostsLanguage = null;
            if (filter.Bedrooms == 0) filter.Bedrooms = null;
            if (filter.Beds == 0) filter.Beds = null;
            if (filter.Bathrooms == 0) filter.Bathrooms = null;
            //ICollection<RentalApartmentDTOForStartPage> rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            var filteredApartments = await Database.SearchRentalApartment.GetFilteredApartments(
                filter.TypeAccommodation, filter.TypeOfHousing, filter.MinimumPrice,
                filter.MaximumPrice, filter.Bedrooms, filter.Beds, filter.Bathrooms, filter.Rating,
                filter.OfferedAmenitiesDTO, filter.HostsLanguage);
            //foreach (var item in filteredApartments)
            //{
            //    RentalApartmentDTOForStartPage dTOForStartPage = await NewRentalApartment(item);
            //    rentalApartmentResult.Add(dTOForStartPage);
            //}
            return filteredApartments;

        }
        public async Task<IEnumerable<RentalApartment>> GetNearestRooms(string ingMap, string latMap)
        {

            //ingMap = ingMap.Replace('.', ',');
            //latMap = latMap.Replace('.', ',');
            //ICollection<RentalApartment> rentalApartmentResult = new List<RentalApartment>();
            var filteredApartments = await Database.SearchRentalApartment.GetNearestApartments(ingMap, latMap);
            //foreach (var item in filteredApartments)
            //{
            //    RentalApartmentDTOForStartPage dTOForStartPage = await NewRentalApartment(item);
            //    rentalApartmentResult.Add(dTOForStartPage);
            //}
            return filteredApartments;
        }

        async Task<RentalApartmentDTOWithBooking> IServiceForSorting<RentalApartmentDTOWithBooking>.NewRentalApartment(RentalApartment apartment)
        {
            List<DateBookingAlex> dateBookingAlex = [];
            if (apartment.Booking != null)
            {

                foreach (var item in apartment.Booking)
                {
                    DateBookingAlex date = new()
                    {
                        Start = item.CheckInDate,
                        End = item.CheckInDate
                    };
                    dateBookingAlex.Add(date);
                }
            }
            var rentalApartmentTemp = new RentalApartmentDTOWithBooking
            {
                Id = apartment.Id,
                Title = apartment.Title,
                IngMap = apartment.IngMap,
                LatMap = apartment.LatMap,
                PricePerNight = apartment.PricePerNight,
                ObjectRating = apartment.ObjectRating,
                Country = apartment.Country.Name + apartment.Address,
                Pictures = apartment.Pictures,
                DateBookingAlex = dateBookingAlex,
                BookingFree = FormatDate(apartment)
            };
            return rentalApartmentTemp;
        }
    }
}
