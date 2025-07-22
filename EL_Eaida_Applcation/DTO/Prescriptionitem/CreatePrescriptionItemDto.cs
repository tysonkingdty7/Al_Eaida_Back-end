using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.Prescriptionitem
{
    public class CreatePrescriptionItemDto
    {
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
    }
}
