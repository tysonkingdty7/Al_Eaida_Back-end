﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public string UserId { get; set; }      
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public virtual User User { get; set; }  
    }
}
