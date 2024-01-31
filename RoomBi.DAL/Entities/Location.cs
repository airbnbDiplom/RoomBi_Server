using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Entities
{
    public class Location
    {
        public Location()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // На озері// Арктика 

        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
