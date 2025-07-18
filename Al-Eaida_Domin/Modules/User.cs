using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Al_Eaida_Domin.Modules
{
    public class User : IdentityUser
    {
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Phone {  get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<MedicalVisit> medicalVisits { get; set; }
        public virtual ICollection<Invoice> CreatedInvoices { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
