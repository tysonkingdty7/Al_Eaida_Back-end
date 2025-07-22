using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.DTO.IncoiceDTO
{
    public class UpdateInvoiceDto
    {
         public Guid Id { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
         
        public List<UpdateInvoiceItemDto>? Items { get; set; }
        public Guid PatientId { get; internal set; }
        public string? CreatedBy { get; internal set; }
    }

}
