using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.UserDTo;

namespace EL_Eaida_Applcation.DTO.TokenDTO
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Refresh { get; set; }
        public UserDTO User { get; set; }
    }
}
