using AutoMapper;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi.DAL.Entities;
using RoomBi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.Services
{
    public class DataSearchForSortingServise(IUnitOfWork uow) : 
        IServiceDataSearchForSorting<RentalApartmentDTOForStartPage>
    {
        IUnitOfWork Database { get; set; } = uow;


        public async Task<IEnumerable<RentalApartmentDTOForStartPage>> GetAllByType(string type)
        {
            try
            {
                ICollection<RentalApartmentDTOForStartPage> rentalApartmentDTO = new List<RentalApartmentDTOForStartPage>();

                if (type != null)
                {
                    switch (type)
                    {
                        case "Country":
                            return null;
                        case "Европа":
                            var rentalApartments = await Database.SearchRentalApartment.GetApartmentsByContinent(type);
                            var mapper = new MapperConfiguration(cfg =>
                            {
                                cfg.CreateMap<RentalApartment, RentalApartmentDTOForStartPage>()
                                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name));
                            }).CreateMapper();
                            return mapper.Map<IEnumerable<RentalApartment>, IEnumerable<RentalApartmentDTOForStartPage>>(rentalApartments);
                        case "City":
                            return null;
                        default:
                            return null;
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return null;
        }
    }
}
