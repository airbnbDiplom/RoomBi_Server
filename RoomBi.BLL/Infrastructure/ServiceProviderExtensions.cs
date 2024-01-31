﻿using Microsoft.Extensions.DependencyInjection;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.Services;
using RoomBi.DAL.EF;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddDbContext<RBContext>();  
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IServiceOfAll<LanguageDTO>, LanguageService>();
            services.AddScoped<IServiceOfAll<CountryDTO>, CountryService>();
            services.AddScoped<IServiceOfAll<ChatDTO>, ChatService>();
            services.AddScoped<IServiceOfAll<BookingDTO>, BookingService>();
            services.AddScoped<IServiceOfAll<EmergencyContactPersonDTO>, EmergencyContactPersonService>();
            services.AddScoped<IServiceOfAll<GuestPaymentMethodDTO>, GuestPaymentMethodService>();
            services.AddScoped<IServiceOfAll<GuestСommentsDTO>, GuestСommentsService>();
            services.AddScoped<IServiceOfAll<OfferedAmenitiesDTO>, OfferedAmenitiesService>();
            services.AddScoped<IServiceOfAll<PictureDTO>, PictureService>();
            services.AddScoped<IServiceOfAll<ProfileDTO>, ProfileService>();
            services.AddScoped<IServiceOfAll<LocationDTO>, LocationService>();
            services.AddScoped<IServiceOfAll<HouseDTO>, HouseService>();
            services.AddScoped<IServiceOfAll<SportDTO>, SportService>();
            services.AddScoped<IServiceOfAll<RentalApartmentDTO>, RentalApartmentService>();
            services.AddScoped<IServiceOfAll<UserDTO>, UserService>();
            services.AddScoped<IServiceOfAll<WishlistDTO>, WishlistService>();
            services.AddScoped<IServiceOfAll<CommentsAboutGuestDTO>, CommentsAboutGuestService>();
            services.AddScoped<IServiceForStartPage<RentalApartmentDTOForStartPage>, RentalApartmentService>();
                                                                    

        }
    }
}
