using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.Prescriptionitem
{
    public  class UpdatePrescriptionItemDto
    { 
        public Guid Id { get; set; }
        public string ?Dosage { get; set; }
        public string ? Duration { get; set; }
        public Guid ?PrescriptionId { get; set; }
        public Guid MedicineId { get; set; }
    }
}
