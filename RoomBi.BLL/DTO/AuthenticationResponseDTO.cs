using RoomBi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBi.BLL.DTO
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }


    }
}
