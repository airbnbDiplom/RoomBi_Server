using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class LocationDTO
    {
        public LocationDTO()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // На озері// Арктика 
        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
