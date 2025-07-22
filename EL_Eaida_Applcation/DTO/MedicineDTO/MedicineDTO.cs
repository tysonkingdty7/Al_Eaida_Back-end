using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.MedicineDTO
{
    public class MedicineDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public Guid  PrescriptionitemId { get; set; }
    }
}
