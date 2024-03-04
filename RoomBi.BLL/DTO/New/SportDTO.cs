using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO.New
{
    public class SportDTO
    {
        public SportDTO()
        {
            RentalApartments = new HashSet<RentalApartment>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }  // Golf// Skiing 

        public ICollection<RentalApartment> RentalApartments { get; set; }
    }
}
