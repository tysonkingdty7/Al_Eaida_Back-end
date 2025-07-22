using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.DTO.PatientsDTO
{
    public  class UpDateMedicineDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public PrescriptionItemDto PrescriptionItem { get; set; }
    }
}
