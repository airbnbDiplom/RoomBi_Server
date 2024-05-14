using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi.DAL.Interfaces;
using System.Globalization;


namespace RoomBi.BLL.Services
{
    public class DataSearchForSortingServise(IUnitOfWork uow) :
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage>
    {
        IUnitOfWork Database { get; set; } = uow;
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> AlexSearch(DataSearchForSorting dataSearchForSorting, int page, int pageSize)
        {
            IEnumerable<RentalApartment> rentalApartments = await Database.SearchRentalApartment.GetObjectForAlex(
                dataSearchForSorting.When.Start,
                dataSearchForSorting.When.End,
                dataSearchForSorting?.Where?.Type,
                dataSearchForSorting?.Where?.CountryCode,
                dataSearchForSorting?.Where?.PlaceId,
                dataSearchForSorting?.Why, 
                page, pageSize);
            var rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            foreach (var item in rentalApartments)
            {
                    RentalApartmentDTOForStartPage result = await NewRentalApartmentWithBooking(item);
                    rentalApartmentResult.Add(result);
            }
            return rentalApartmentResult;
        }
        public async Task<RentalApartmentDTOForStartPage> NewRentalApartmentWithBooking(RentalApartment apartment)
        {
            var rentalApartmentTemp = new RentalApartmentDTOForStartPage
            {
                Id = apartment.Id,
                Title = apartment.Title,
                IngMap = apartment.IngMap,
                LatMap = apartment.LatMap,
                PricePerNight = apartment.PricePerNight,
                ObjectRating = apartment.ObjectRating,
                Country = apartment.Country.Name + " " + apartment.Address,
                Pictures = apartment.Pictures,
                BookingFree = FormatDate(apartment)
            };
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
        public async Task<RentalApartmentDTOForStartPage> NewRentalApartment(RentalApartment apartment)
        {
          
            var rentalApartmentTemp = new RentalApartmentDTOForStartPage
            {
                Id = apartment.Id,
                Title = apartment.Title,
                IngMap = apartment.IngMap,
                LatMap = apartment.LatMap,
                PricePerNight = apartment.PricePerNight,
                ObjectRating = apartment.ObjectRating,
                Country = apartment.Country.Name + " " + apartment.Address,
                Pictures = apartment.Pictures,
                BookingFree = FormatDate(apartment)
            };
            return rentalApartmentTemp;
        }
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllByFilter(Filter filter)
        {
            if (filter.TypeOfHousing != null && filter.TypeOfHousing.Count() == 0) filter.TypeOfHousing = null;
            if (filter.OfferedAmenitiesDTO != null && filter.OfferedAmenitiesDTO.Count() == 0) filter.OfferedAmenitiesDTO = null;
            if (filter.HostsLanguage != null && filter.HostsLanguage.Count() == 0) filter.HostsLanguage = null;
            if (filter.Bedrooms == 0) filter.Bedrooms = null;
            if (filter.Beds == 0) filter.Beds = null;
            if (filter.Bathrooms == 0) filter.Bathrooms = null;
            ICollection<RentalApartmentDTOForStartPage> rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            var filteredApartments = await Database.SearchRentalApartment.GetFilteredApartments(
                filter.TypeAccommodation, filter.TypeOfHousing, filter.MinimumPrice,
                filter.MaximumPrice, filter.Bedrooms, filter.Beds, filter.Bathrooms, filter.Rating,
                filter.OfferedAmenitiesDTO, filter.HostsLanguage);
            foreach (var item in filteredApartments)
            {
                RentalApartmentDTOForStartPage dTOForStartPage = await NewRentalApartment(item);
                rentalApartmentResult.Add(dTOForStartPage);
            }
            return rentalApartmentResult;

        }
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetNearestRooms(string ingMap, string latMap)
        {
            ICollection<RentalApartmentDTOForStartPage> rentalApartmentResult = new List<RentalApartmentDTOForStartPage>();
            var filteredApartments = await Database.SearchRentalApartment.GetNearestApartments(ingMap, latMap);
            foreach (var item in filteredApartments)
            {
                RentalApartmentDTOForStartPage dTOForStartPage = await NewRentalApartment(item);
                rentalApartmentResult.Add(dTOForStartPage);
            }
            return rentalApartmentResult;
        }
    }
}
