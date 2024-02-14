﻿using AutoMapper;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL;
using RoomBi.BLL.Infrastructure;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.DTO;
using RoomBi.DAL.Entities;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using RoomBi.DAL.Repositories;
using System.Net;


namespace RoomBi.BLL.Services
{
    public class RentalApartmentService(IUnitOfWork uow) : IServiceOfAll<RentalApartmentDTO>,
        IServiceForStartPage<RentalApartmentDTOForStartPage>,
        IServiceForMap<RentalApartmentForMap>
    {
        private readonly IUnitOfWork Database = uow;
        public async Task Create(RentalApartmentDTO rentalApartmentDTO)
        {
            var rentalApartment = new RentalApartment
            {
                Id = rentalApartmentDTO.Id,
                Title = rentalApartmentDTO.Title,
                Address = rentalApartmentDTO.Address,
                IngMap = rentalApartmentDTO.IngMap,
                LatMap = rentalApartmentDTO.LatMap,
                NumberOfGuests = rentalApartmentDTO.NumberOfGuests,
                Bedrooms = rentalApartmentDTO.Bedrooms,
                Bathrooms = rentalApartmentDTO.Bathrooms,
                Beds = rentalApartmentDTO.Beds,
                PricePerNight = rentalApartmentDTO.PricePerNight,
                ObjectRating = rentalApartmentDTO.ObjectRating,
                ObjectState = rentalApartmentDTO.ObjectState,
                //OfferedAmenitiesId = rentalApartmentDTO.OfferedAmenitiesId,
                TypeApartment = rentalApartmentDTO.TypeApartment,
                //PropertyTypeId = rentalApartmentDTO.PropertyTypeId,
                //CountryId = rentalApartmentDTO.CountryId
            };
            await Database.RentalApartment.Create(rentalApartment);
            await Database.Save();
        }
        public async Task Update(RentalApartmentDTO rentalApartmentDTO)
        {
            var rentalApartment = new RentalApartment
            {
                Id = rentalApartmentDTO.Id,
                Title = rentalApartmentDTO.Title,
                Address = rentalApartmentDTO.Address,
                IngMap = rentalApartmentDTO.IngMap,
                LatMap = rentalApartmentDTO.LatMap,
                NumberOfGuests = rentalApartmentDTO.NumberOfGuests,
                Bedrooms = rentalApartmentDTO.Bedrooms,
                Bathrooms = rentalApartmentDTO.Bathrooms,
                Beds = rentalApartmentDTO.Beds,
                PricePerNight = rentalApartmentDTO.PricePerNight,
                ObjectRating = rentalApartmentDTO.ObjectRating,
                ObjectState = rentalApartmentDTO.ObjectState,
                //OfferedAmenitiesId = rentalApartmentDTO.OfferedAmenitiesId,
                TypeApartment = rentalApartmentDTO.TypeApartment,
                //PropertyTypeId = rentalApartmentDTO.PropertyTypeId,
                //CountryId = rentalApartmentDTO.CountryId
            };
            await Database.RentalApartment.Update(rentalApartment);
            await Database.Save();
        }
        public async Task Delete(int id)
        {
            await Database.RentalApartment.Delete(id);
            await Database.Save();
        }
        public async Task<RentalApartmentDTO> Get(int id)
        {
            var rentalApartment = await Database.RentalApartment.Get(id);
            if (rentalApartment == null)
                throw new ValidationException("Wrong rentalApartment!", "");
            return new RentalApartmentDTO
            {
                Id = rentalApartment.Id,
                Title = rentalApartment.Title,
                Address = rentalApartment.Address,
                IngMap = rentalApartment.IngMap,
                LatMap = rentalApartment.LatMap,
                NumberOfGuests = rentalApartment.NumberOfGuests,
                Bedrooms = rentalApartment.Bedrooms,
                Bathrooms = rentalApartment.Bathrooms,
                Beds = rentalApartment.Beds,
                PricePerNight = rentalApartment.PricePerNight,
                ObjectRating = rentalApartment.ObjectRating,
                ObjectState = rentalApartment.ObjectState,
                TypeApartment = rentalApartment.TypeApartment,
                User = rentalApartment.User,
                Location = rentalApartment.Location?.Name,
                Sport = rentalApartment.Sport?.Name,
                House = rentalApartment.House?.Name,
                Country = rentalApartment.Country?.Name,
                OfferedAmenities = rentalApartment.OfferedAmenities,
                GuestComments = rentalApartment.GuestComments,
                Pictures = rentalApartment.Pictures,
                Booking = rentalApartment.Booking,
                Chats = rentalApartment.Chats
            };
        }
        public async Task<RentalApartmentDTOForStartPage> GetCard(int id)
        {
            var rentalApartment = await Database.RentalApartment.Get(id);
            if (rentalApartment == null)
                throw new ValidationException("Wrong rentalApartment!", "");
            return new RentalApartmentDTOForStartPage
            {
                Id = rentalApartment.Id,
                Title = rentalApartment.Title,
                IngMap = rentalApartment.IngMap,
                LatMap = rentalApartment.LatMap,
                PricePerNight = rentalApartment.PricePerNight,
                ObjectRating = rentalApartment.ObjectRating,
                Location = rentalApartment.Location?.Name,
                Sport = rentalApartment.Sport?.Name,
                House = rentalApartment.House?.Name,
                Country = rentalApartment.Country?.Name,
                Pictures = rentalApartment.Pictures,
                BookingFree = null
            };
        }
        public async Task<IEnumerable<RentalApartmentDTO>> GetAll()
        {
            var rentalApartments = await Database.RentalApartment.GetAll();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalApartment, RentalApartmentDTO>()
                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
            }).CreateMapper();
            return mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentDTO>>(rentalApartments);
        }
        public async Task<IEnumerable<RentalApartmentForMap>> GetAllForMap(string map)
        {
            var rentalApartments = await Database.RentalApartment.GetAll();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalApartment, RentalApartmentForMap>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.House, opt => opt.MapFrom(src => src.House.Name))
                .ForMember(dest => dest.Sport, opt => opt.MapFrom(src => src.Sport.Name));

            }).CreateMapper();
            return mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentForMap>>(rentalApartments);
        }
        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllForStartPage(int page, int pageSize)
        {
            if (page == 1) 
            {
                var rentalApartments = await Database.Apartment24.Get24(page, pageSize);
                List<RentalApartmentDTOForStartPage> rentalApartmentList = [];
                foreach (var apartment in rentalApartments)
                {
                    var rentalApartmentDto = new RentalApartmentDTOForStartPage
                    {
                        Title = apartment.Title,
                        IngMap = apartment.IngMap,
                        LatMap = apartment.LatMap,  
                        PricePerNight = apartment.PricePerNight, 
                        ObjectRating = apartment.ObjectRating,
                        Country = apartment.Country?.Name,
                        Location = apartment.Location?.Name,
                        House = apartment.House?.Name,
                        Sport = apartment.Sport?.Name,
                        Pictures = apartment.Pictures,
                        
                    };
                    rentalApartmentDto.Country += ", " + apartment.Address;
                    rentalApartmentDto.BookingFree = FormatDate(apartment);

                    rentalApartmentList.Add(rentalApartmentDto);
                }
                return rentalApartmentList;
            }
            else
            {
                var rentalApartments = await Database.RentalApartment.GetAll();
                List<RentalApartmentDTOForStartPage> rentalApartmentList = [];
                foreach (var apartment in rentalApartments)
                {
                    var rentalApartmentDto = new RentalApartmentDTOForStartPage
                    {
                        Title = apartment.Title,
                        IngMap = apartment.IngMap,
                        LatMap = apartment.LatMap,
                        PricePerNight = apartment.PricePerNight,
                        ObjectRating = apartment.ObjectRating,
                        Country = apartment.Country?.Name,
                        Location = apartment.Location?.Name,
                        House = apartment.House?.Name,
                        Sport = apartment.Sport?.Name,
                        Pictures = apartment.Pictures,

                    };
                    rentalApartmentDto.Country += ", " + apartment.Address;
                    rentalApartmentDto.BookingFree = FormatDate(apartment);

                    rentalApartmentList.Add(rentalApartmentDto);
                }

                return rentalApartmentList;
            }
        }
        public static string FormatDate(RentalApartment rentalApartment)
        {
            if (rentalApartment.Booking == null || rentalApartment.Booking.Count == 0)
            {
                return string.Empty;
            }

            var bookings = rentalApartment.Booking.OrderBy(b => b.CheckOutDate).ToList();
            DateTime lastCheckOutDate = bookings.First().CheckOutDate;

            foreach (var booking in bookings.Skip(1))
            {
                DateTime nextCheckInDate = booking.CheckInDate;
                TimeSpan difference = nextCheckInDate - lastCheckOutDate;
                if (difference.Days >= 5)
                {
                    lastCheckOutDate = booking.CheckOutDate;
                }
            }

            DateTime newDate = lastCheckOutDate.AddDays(5);
            string formattedDate = lastCheckOutDate.ToString("dd MMM", new System.Globalization.CultureInfo("uk-UA")) +
                                    " - " +
                                    newDate.ToString("dd MMM", new System.Globalization.CultureInfo("uk-UA"));
            return formattedDate;
        }



    }
}
