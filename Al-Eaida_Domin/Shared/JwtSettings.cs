﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Shared
{
    public class JwtSettings
    {

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
