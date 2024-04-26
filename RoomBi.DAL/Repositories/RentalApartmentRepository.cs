using Azure;
using Microsoft.EntityFrameworkCore;
using RoomBi.DAL.EF;
using RoomBi.DAL.Entities;
using RoomBi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Repositories
{
    public class RentalApartmentRepository(RBContext context) :
        IRepositoryOfAll<RentalApartment>,
        IRepositoryGet24<RentalApartment>,
        IRepositorySearch<RentalApartment>
    {
        private readonly RBContext context = context;

        public async Task<RentalApartment> Get(int id)
        {

            var rentalApartment = await context.RentalApartments/*.Include(r => r.Pictures)*/
                                                                //.Include(r => r.Booking)
                                                                //.Include(r => r.Chats)
                                                                //.Include(r => r.GuestComments)
                                                                .Include(r => r.Location)
                                                                .Include(r => r.House)
                                                                .Include(r => r.Sport)
                                                                .Include(r => r.Country)
                                                                .Include(r => r.User)
                                                                .Include(r => r.OfferedAmenities)
                                                                .FirstOrDefaultAsync(m => m.Id == id);
            //var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            var chatRepository = new ChatRepository(context);
            var guestCommentsRepository = new GuestCommentsRepository(context);
            if (rentalApartment != null)
            {
                rentalApartment.Pictures = (ICollection<Picture>)await pictureRepository.GetAllById(id);
                rentalApartment.Booking = await context.Bookings.Where(booking => booking.ApartmentId == id).OrderBy(booking => booking.CheckInDate).ToListAsync();


                rentalApartment.Chats = (ICollection<Chat>)await chatRepository.GetAllById(id);
                rentalApartment.GuestComments = (ICollection<GuestComments>)await guestCommentsRepository.GetAllById(id);
            }
            await context.SaveChangesAsync();
            return rentalApartment;
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
        public async Task<IEnumerable<RentalApartment>> Get24(int page, int pageSize)
        {
            var temp = await context.RentalApartments
                .Include(ra => ra.Country)
                .Include(ra => ra.Location)
                .Include(ra => ra.House)
                .Include(ra => ra.Sport)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var apartment = temp[i];
                var bookings = await bookingRepository.GetAllById(apartment.Id);
                var pictures = await pictureRepository.GetAllById(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }

            return temp.OrderBy(ra => ra.Id);
        }
        public async Task<IEnumerable<RentalApartment>> GetAll()
        {
            var temp = await context.RentalApartments
                 .Include(ra => ra.Country)
                 .Include(ra => ra.Location)
                 .Include(ra => ra.House)
                 .Include(ra => ra.Sport)
                 .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var apartment = temp[i];
                var bookings = await bookingRepository.GetAllById(apartment.Id);
                var pictures = await pictureRepository.GetAllById(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }
            return temp.OrderBy(ra => ra.Id);
        }

        //public async Task<IEnumerable<RentalApartment>> GetApartmentsByContinent(string continent)
        //{
        //    var continentId = await context.Сontinent
        //  .Where(c => c.Name == continent)
        //  .Select(c => c.Id)
        //  .FirstOrDefaultAsync();

        //    if (continentId == 0)
        //    {
        //        return Enumerable.Empty<RentalApartment>();
        //    }
        //    return await context.RentalApartments
        //   .Where(apartment => apartment.СontinentId == continentId)
        //   .ToListAsync();
        //}
        //public async Task<IEnumerable<RentalApartment>> GetApartmentsByCountry(string country)
        //{
        //    var countryId = await context.Countries
        //   .Where(c => c.Name == country)
        //   .Select(c => c.Id)
        //   .FirstOrDefaultAsync();

        //    if (countryId == 0)
        //    {
        //        return Enumerable.Empty<RentalApartment>();
        //    }
        //    return await context.RentalApartments
        //   .Where(apartment => apartment.CountryId == countryId)
        //   .ToListAsync();
        //}

        public async Task<IEnumerable<RentalApartment>> GetApartmentsByCity(int? placeId)
        {
            var cityApartments = await context.RentalApartments
            .Where(apartment => apartment.PlaceId == placeId)
            .ToListAsync();
            if (cityApartments.Count == 0)
            {
                return Enumerable.Empty<RentalApartment>();
            }
            return cityApartments;
        }
        public async Task<IEnumerable<RentalApartment>> GetApartmentsByUser(int? userId)
        {
            var cityApartments = await context.RentalApartments
            .Where(apartment => apartment.UserId == userId)
            .ToListAsync();
            if (cityApartments.Count == 0)
            {
                return Enumerable.Empty<RentalApartment>();
            }
            return cityApartments;
        }
        public async Task<RentalApartment> GetApartmentsByDateBooking(DateTime start, DateTime end, int? idApartment)
        {
            var bookings = await context.Bookings
                .Where(b => b.ApartmentId == idApartment && b.CheckInDate <= end && b.CheckOutDate >= start)
                .ToListAsync();

            if (bookings.Count == 0)
            {
                var apartment = await context.RentalApartments
                    .Include(a => a.Booking)
                    .Include(a => a.GuestComments)
                    .Include(a => a.Pictures)
                    .Include(a => a.Chats)
                    .SingleOrDefaultAsync(a => a.Id == idApartment);

                return apartment;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<RentalApartment>> GetAllMinForSearch()
        {
            var temp = await context.RentalApartments.ToListAsync();
            var bookingRepository = new BookingRepository(context);
            for (int i = 0; i < temp.Count; i++)
            {
                var apartment = temp[i];
                var bookings = await bookingRepository.GetAllById(apartment.Id);
                apartment.Booking = bookings.ToList();
            }
            return temp.OrderBy(ra => ra.Id);
        }

        public async Task<IEnumerable<RentalApartment>> GetApartmentsByNumberOfGuests(int? why)
        {
            var whyApartments = await context.RentalApartments
           .Where(apartment => apartment.NumberOfGuests >= why)
           .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < whyApartments.Count; i++)
            {
                var apartment = whyApartments[i];
                var bookings = await bookingRepository.GetAllById(apartment.Id);
                var pictures = await pictureRepository.GetAllById(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }
            if (whyApartments.Count == 0)
            {
                return Enumerable.Empty<RentalApartment>();
            }
            return whyApartments;
        }

        public async Task<IEnumerable<RentalApartment>> GetFilteredApartments(
            string? typeAccommodation, string[]? typeOfHousing,
            int? minimumPrice, int? maximumPrice, int? bedrooms,
            int? beds, int? bathrooms, bool rating,
            string[]? offeredAmenitiesDTO, string[]? hostsLanguage)
        {
            var temp = await context.RentalApartments
                .Include(ra => ra.Country)
                .ToListAsync();
            var filteredApartments = temp
                .Where(apartment =>
                    apartment.PricePerNight >= minimumPrice &&
                    apartment.PricePerNight <= maximumPrice &&
                    (!rating || apartment.ObjectRating == 5) &&
                    (bedrooms == null || apartment.Bedrooms == bedrooms) &&
                    (beds == null || apartment.Beds == beds) &&
                    (bathrooms == null || apartment.Bathrooms == bathrooms))
                .ToList();

            List<RentalApartment> result = [];
            if (offeredAmenitiesDTO != null)
            {
                var offeredAmenitiesRepository = new OfferedAmenitiesRepository(context);

                for (int i = 0; i < filteredApartments.Count; i++)
                {
                    var apartment = filteredApartments[i];
                    var offeredAmenities = await offeredAmenitiesRepository.Get(temp[i].OfferedAmenitiesId);
                    {
                        if (offeredAmenitiesDTO.Contains("wiFi", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.WiFi) continue;
                        if (offeredAmenitiesDTO.Contains("tV", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.TV) continue;
                        if (offeredAmenitiesDTO.Contains("kitchen", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Kitchen) continue;
                        if (offeredAmenitiesDTO.Contains("washingMachine", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.WashingMachine) continue;
                        if (offeredAmenitiesDTO.Contains("airConditioner", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.AirConditioner) continue;
                        if (offeredAmenitiesDTO.Contains("workspace", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Workspace) continue;
                        if (offeredAmenitiesDTO.Contains("firstAidKit", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.FirstAidKit) continue;
                        if (offeredAmenitiesDTO.Contains("fireExtinguisher", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.FireExtinguisher) continue;
                        if (offeredAmenitiesDTO.Contains("freeParking", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.FreeParking) continue;
                        if (offeredAmenitiesDTO.Contains("paidParking", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.PaidParking) continue;
                        if (offeredAmenitiesDTO.Contains("pool", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Pool) continue;
                        if (offeredAmenitiesDTO.Contains("jacuzzi", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Jacuzzi) continue;
                        if (offeredAmenitiesDTO.Contains("innerYard", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.InnerYard) continue;
                        if (offeredAmenitiesDTO.Contains("bBQArea", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.BBQArea) continue;
                        if (offeredAmenitiesDTO.Contains("outdoorDiningArea", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.OutdoorDiningArea) continue;
                        if (offeredAmenitiesDTO.Contains("firePit", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.FirePit) continue;
                        if (offeredAmenitiesDTO.Contains("fireplace", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Fireplace) continue;
                        if (offeredAmenitiesDTO.Contains("poolTable", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.PoolTable) continue;
                        if (offeredAmenitiesDTO.Contains("piano", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.Piano) continue;
                        if (offeredAmenitiesDTO.Contains("gymEquipment", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.GymEquipment) continue;
                        if (offeredAmenitiesDTO.Contains("outdoorShower", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.OutdoorShower) continue;
                        if (offeredAmenitiesDTO.Contains("lakeAccess", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.LakeAccess) continue;
                        if (offeredAmenitiesDTO.Contains("beachAccess", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.BeachAccess) continue;
                        if (offeredAmenitiesDTO.Contains("skiInOut", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.SkiInOut) continue;
                        if (offeredAmenitiesDTO.Contains("carbonMonoxideDetector", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.CarbonMonoxideDetector) continue;
                        if (offeredAmenitiesDTO.Contains("smokeDetector", StringComparer.OrdinalIgnoreCase)) if (!offeredAmenities.SmokeDetector) continue;
                        result.Add(apartment);

                    }
                }
                List<RentalApartment> result2 = [];
                result2 = result.Where(apartment =>
                {
                    if (typeAccommodation == "Будь-який")
                    {
                        return true;
                    }
                    else if (typeAccommodation == "Ціле помешкання")
                    {
                        return apartment.TypeApartment == "Ціле помешкання";
                    }
                    else if (typeAccommodation == "Кімната")
                    {
                        return apartment.TypeApartment == "Кімната";
                    }
                    else
                    {
                        return false;
                    }
                }).ToList();
                var bookingRepository = new BookingRepository(context);
                var pictureRepository = new PictureRepository(context);
                for (int i = 0; i < result2.Count; i++)
                {
                    var apartment = result2[i];
                    var bookings = await bookingRepository.GetAllById(apartment.Id);
                    var pictures = await pictureRepository.GetAllById(apartment.Id);

                    apartment.Booking = bookings.ToList();
                    apartment.Pictures = pictures.ToList();
                }
                return result2;
            }
            else
            {
                List<RentalApartment> result3 = [];
                result3 = filteredApartments.Where(apartment =>
            {
                if (typeAccommodation == "Будь-який")
                {
                    return true;
                }
                else if (typeAccommodation == "Ціле помешкання")
                {
                    return apartment.TypeApartment == "Ціле помешкання";
                }
                else if (typeAccommodation == "Кімната")
                {
                    return apartment.TypeApartment == "Кімната";
                }
                else
                {
                    return false;
                }
            }).ToList();
            var bookingRepository2 = new BookingRepository(context);
            var pictureRepository2 = new PictureRepository(context);
            for (int i = 0; i < result3.Count; i++)
            {
                var apartment = result3[i];
                var bookings = await bookingRepository2.GetAllById(apartment.Id);
                var pictures = await pictureRepository2.GetAllById(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }
            return result3;
            }
        }



        public async Task<IEnumerable<RentalApartment>> GetApartmentsByCountryCode(string? CountryCode)
        {
            var cityApartments = await context.RentalApartments
             .Where(apartment => apartment.CountryCode == CountryCode)
             .ToListAsync();
            var bookingRepository = new BookingRepository(context);
            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < cityApartments.Count; i++)
            {
                var apartment = cityApartments[i];
                var bookings = await bookingRepository.GetAllById(apartment.Id);
                var pictures = await pictureRepository.GetAllById(apartment.Id);

                apartment.Booking = bookings.ToList();
                apartment.Pictures = pictures.ToList();
            }
            if (cityApartments.Count == 0)
            {
                return Enumerable.Empty<RentalApartment>();
            }
            return cityApartments;
        }



        //public async Task<List<RentalApartment>> GetNearestApartments(string ingMap, string latMap)
        //{
        //    if (!double.TryParse(ingMap, out double ing) || !double.TryParse(latMap, out double lat))
        //    {
        //        throw new ArgumentException("Invalid coordinates format");
        //    }
        //    var allApartments = await context.RentalApartments.ToListAsync();

        //    var nearestApartments = allApartments
        //        .Select(apartment => new
        //        {
        //            Apartment = apartment,
        //            Distance = Math.Sqrt(Math.Pow(double.Parse(apartment.LatMap.Replace('.', ',')) - ing, 2) +
        //                     Math.Pow(double.Parse(apartment.IngMap.Replace('.', ',')) - lat, 2))
        //        })
        //        .OrderBy(apartment => apartment.Distance)
        //        .Take(10)
        //        .Select(apartment => apartment.Apartment)
        //        .ToList();
        //    var pictureRepository = new PictureRepository(context);
        //    for (int i = 0; i < nearestApartments.Count; i++)
        //    {
        //        var apartment = nearestApartments[i];
        //        var pictures = await pictureRepository.ByApartmentId(apartment.Id);
        //        apartment.Pictures = pictures.ToList();
        //    }
        //    return nearestApartments;
        //}


        public async Task<List<RentalApartment>> GetNearestApartments(string ingMap, string latMap)
        {
            if (!double.TryParse(ingMap, NumberStyles.Float, CultureInfo.InvariantCulture, out double ing) ||
                !double.TryParse(latMap, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat))
            {
                throw new ArgumentException("Invalid coordinates format");
            }

            var allApartments = await context.RentalApartments.ToListAsync();

            var nearestApartments = allApartments
                .Select(apartment => new
                {
                    Apartment = apartment,
                    Distance = Math.Sqrt(Math.Pow(double.Parse(apartment.LatMap, CultureInfo.InvariantCulture) - lat, 2) +
                                         Math.Pow(double.Parse(apartment.IngMap, CultureInfo.InvariantCulture) - ing, 2))
                })
                .OrderBy(apartment => apartment.Distance)
                .Take(10)
                .Select(apartment => apartment.Apartment)
                .ToList();

            var pictureRepository = new PictureRepository(context);
            for (int i = 0; i < nearestApartments.Count; i++)
            {
                var apartment = nearestApartments[i];
                var pictures = await pictureRepository.GetAllById(apartment.Id);
                apartment.Pictures = pictures.ToList();
            }

            return nearestApartments;
        }


    }
}



