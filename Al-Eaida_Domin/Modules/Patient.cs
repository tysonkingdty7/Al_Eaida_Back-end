using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MedicalHistory { get; set; }
        public virtual ICollection<MedicalVisit> MedicalVisits { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
