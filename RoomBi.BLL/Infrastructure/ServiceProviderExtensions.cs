
using Microsoft.Extensions.DependencyInjection;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.BLL.Services;
using RoomBi.DAL;
using RoomBi.DAL.EF;
using RoomBi.DAL.Interfaces;
using RoomBi.DAL.Repositories;


namespace RoomBi.BLL.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddDbContext<RBContext>();  
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();

            services.AddScoped<IServiceOfAll<CountryDTO>, CountryService>();
            services.AddScoped<IServiceOfAll<UserDTO>, UserService>();
            services.AddScoped<IServiceOfAll<UserDTOProfile>, UserService>();
            services.AddScoped<IServiceOfAll<WishlistDTO>, WishlistService>();
            services.AddScoped<IServiceOfAll<Payment>, GuestPaymentMethodService>();
            services.AddScoped<IServiceOfAll<GuestComments>, GuestСommentsService>();
            services.AddScoped<IServiceOfAll<ProfileDTO>, ProfileService>();


            services.AddScoped<IServiceCreate<ChatForApartmentPageDTO>, ChatService>();

            services.AddScoped<IServiceGetAllIdUser<MessageObj>, BookingService>();
            services.AddScoped<IServiceBooking<BookingDTO>, BookingService>();
            services.AddScoped<IServiceCreate<BookingDTO>, BookingService>();

            services.AddScoped<IServiceGetAllIdUser<BookingDTOWithFoto>, BookingService>();

            services.AddScoped<IServiceProfile<ProfileDTO>, ProfileService>();

            services.AddScoped<IServiceForStartPage<RentalApartmentDTOForStartPage>, RentalApartmentService>();
            services.AddScoped<IServiceForMap<RentalApartmentForMap>, RentalApartmentService>();
            services.AddScoped<IServiceForItem<RentalApartmentDTO>, RentalApartmentService>();

            services.AddScoped<IServiceOfUserGoogle<User>, UserService>();
            services.AddScoped<IServiceOfUser<UserDTO>, UserService>();

            services.AddScoped<IServiceGetAllIdUser<WishlistDTO>, WishlistService>();
     
            services.AddScoped<IServiceDataSearchForSorting<RentalApartmentDTOForStartPage>, DataSearchForSortingServise>();
            services.AddScoped<IServiceCreate<TransferDataDTO>, RentalApartmentService> ();





        }
    }
}
