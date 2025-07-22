using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.InvoiceitemDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IinvoiceitemServices
    {
         Task<InvoiceItemDto> Createinvoiceitem(CreateInvoiceItemDto createInvoiceItemDto);
         Task<InvoiceItemDto> GetInvoiceitemById(Guid id);
        Task<IEnumerable<InvoiceItemDto>> GetAllInvoiceitems(int Pagesize, int pagenumber);
        Task<InvoiceItemDto> UpdateInvoiceitem(Guid id, UpdateInvoiceItemDto updateInvoiceItemDto);
        Task<bool> DeleteInvoiceitem(Guid id);
        Task<IEnumerable<InvoiceItemDto>> GetInvoiceItemsByInvoiceId(Guid invoiceId);

    }
}
