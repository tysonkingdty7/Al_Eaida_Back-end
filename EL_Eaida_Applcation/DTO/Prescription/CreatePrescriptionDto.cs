using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.DTO.Prescription
{
    public class CreatePrescriptionDto
    {
        public Guid VisitId { get; set; }
        public List<CreatePrescriptionItemDto> Items { get; set; }
    }
}
