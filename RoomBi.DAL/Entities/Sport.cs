using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.DAL.Entities
{
    public class Sport
    {
        public Sport()
        {
            this.RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // Golf// Skiing 

        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
