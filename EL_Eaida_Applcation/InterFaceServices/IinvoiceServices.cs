using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.IncoiceDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public  interface IinvoiceServices
    {
         Task<InvoiceDto> Createinvoice(CreateInvoiceDto createInvoiceDto);
        Task<InvoiceDto> GetInvoiceById(Guid id);
        Task<IEnumerable<InvoiceDto>> GetAllInvoices(int Pagesize, int pagenumber);
        Task<InvoiceDto> UpdateInvoice(Guid id, UpdateInvoiceDto updateInvoiceDto);
        Task<bool> DeleteInvoice(Guid id);

    }
}
