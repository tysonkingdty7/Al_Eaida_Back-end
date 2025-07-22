using EL_Eaida_Applcation.DTO.InvoiceitemDTO;
using EL_Eaida_Applcation.InterFaceServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class invoiceitemController : Controller
    {
      protected readonly IinvoiceitemServices _invoiceitemServices;
        public invoiceitemController(IinvoiceitemServices invoiceitemServices)
        {
            _invoiceitemServices = invoiceitemServices;
        }
        [HttpPost("CreateInvoiceItem")]
        public async Task<IActionResult> CreateInvoiceItem([FromBody] CreateInvoiceItemDto value)
        {
            await _invoiceitemServices.Createinvoiceitem(value);
            return Ok("تمت الإضافة بنجاح");
        }
        [HttpGet("GetAllInvoiceItems")]
        public async Task<IActionResult> GetAllInvoiceItems(int pageSize = 10, int pageNumber = 1)
        {
            var invoiceItems = await _invoiceitemServices.GetAllInvoiceitems(pageSize, pageNumber);
            return Ok(invoiceItems);
        }
        [HttpGet("GetInvoiceItemById/{id}")]
        public async Task<IActionResult> GetInvoiceItemById(Guid id)
        {
            var invoiceItem = await _invoiceitemServices.GetInvoiceitemById(id);
            if (invoiceItem == null)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok(invoiceItem);
        }
        [HttpPut("UpdateInvoiceItem")]
        public async Task<IActionResult> UpdateInvoiceItem(Guid id , [FromBody] UpdateInvoiceItemDto updateInvoiceItemDto)
        {
            var updatedItem = await _invoiceitemServices.UpdateInvoiceitem(id, updateInvoiceItemDto);
            if (updatedItem == null)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok(updatedItem);
        }
        [HttpDelete("DeleteInvoiceItem/{id}")]
        public async Task<IActionResult> DeleteInvoiceItem(Guid id)
        {
            var result = await _invoiceitemServices.DeleteInvoiceitem(id);
            if (!result)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok("تم حذف العنصر بنجاح");
        }
    }
}
