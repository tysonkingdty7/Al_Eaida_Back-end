using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Gender { get; set; }
        public string? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
