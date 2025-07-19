using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public class CreatePatientDTO
    {
        
        public string FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? MedicalHistory { get; set; } 
    }
}
