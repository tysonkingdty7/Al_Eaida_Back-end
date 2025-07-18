using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.UserDTo
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ? Address { get; set; }
        public string Phone { get; set; } // اجعلها string لتفادي مشكلة الرقم المبدوء بصفر
        public List<string> Role { get; set; }
    }

}
