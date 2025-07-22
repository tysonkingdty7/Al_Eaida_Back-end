using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.DTO.IncoiceDTO
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public List<InvoiceItemDto> Items { get; set; }
    }

}
