using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class RequestUser
    {
        public string Email { get; set; }  
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
