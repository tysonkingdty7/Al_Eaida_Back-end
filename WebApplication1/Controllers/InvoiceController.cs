using EL_Eaida_Applcation.DTO.IncoiceDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
       protected readonly IinvoiceServices _invoiceServices;
        public InvoiceController(IinvoiceServices invoiceServices)
        {
            _invoiceServices = invoiceServices;
        }
        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceDto value)
        {
            await _invoiceServices.Createinvoice(value);
            return Ok("تمت الإضافة بنجاح");
        }
        [HttpGet("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices(int pageSize = 10, int pageNumber = 1)
        {
            var invoices = await _invoiceServices.GetAllInvoices(pageSize, pageNumber);
            return Ok(invoices);
        }
        [HttpGet("GetInvoiceById/{id}")]
        public async Task<IActionResult> GetInvoiceById(Guid id)
        {
            var invoice = await _invoiceServices.GetInvoiceById(id);
            if (invoice == null)
            {
                return NotFound("الفاتورة غير موجودة");
            }
            return Ok(invoice);
        }
        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice(Guid id,  [FromBody] UpdateInvoiceDto updateInvoiceDto)
        {
            var updatedInvoice = await _invoiceServices.UpdateInvoice(id , updateInvoiceDto);
            if (updatedInvoice == null)
            {
                return NotFound("الفاتورة غير موجودة");
            }
            return Ok(updatedInvoice);
        }
        [HttpDelete("DeleteInvoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var result = await _invoiceServices.DeleteInvoice(id);
            if (!result)
            {
                return NotFound("الفاتورة غير موجودة");
            }
            return Ok("تم حذف الفاتورة بنجاح");
        }
    }
}
