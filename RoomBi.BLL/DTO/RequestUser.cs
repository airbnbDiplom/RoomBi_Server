using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class RequestUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }  
        public string? Password { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
    }
}
