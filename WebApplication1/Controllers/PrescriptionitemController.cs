using EL_Eaida_Applcation.DTO.Prescriptionitem;
using EL_Eaida_Applcation.InterFaceServices.IPresciptionitemServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionitemController : Controller
    {
     protected readonly IPresciptionitemServices _prescriptionitemServices;
        public PrescriptionitemController(IPresciptionitemServices prescriptionitemServices)
        {
            _prescriptionitemServices = prescriptionitemServices;
        }
        [HttpPost("CreatePrescriptionItem")]
        public async Task<IActionResult> CreatePrescriptionItem([FromBody] CreatePrescriptionItemDto value)
        {
            await _prescriptionitemServices.CreatePrescriptionItemAsync(value);
            return Ok("تمت الإضافة بنجاح");
        }
        [HttpGet("GetAllPrescriptionItems")]
        public async Task<IActionResult> GetAllPrescriptionItems(int pageSize = 10, int pageNumber = 1)
        {
            var prescriptionItems = await _prescriptionitemServices.GetAllPrescriptionItemsAsync(pageSize, pageNumber);
            return Ok(prescriptionItems);
        }
        [HttpGet("GetPrescriptionItemById/{id}")]
        public async Task<IActionResult> GetPrescriptionItemById(Guid id)
        {
            var prescriptionItem = await _prescriptionitemServices.GetPrescriptionItemByIdAsync(id);
            if (prescriptionItem == null)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok(prescriptionItem);
        }
        [HttpPut("UpdatePrescriptionItem")]
        public async Task<IActionResult> UpdatePrescriptionItem([FromBody] UpdatePrescriptionItemDto updatePrescriptionItemDto)
        {
            var updatedItem = await _prescriptionitemServices.UpdatePrescriptionItemAsync(updatePrescriptionItemDto);
            if (updatedItem == null)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok(updatedItem);
        }
        [HttpDelete("DeletePrescriptionItem/{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(Guid id)
        {
            var result = await _prescriptionitemServices.DeletePrescriptionItemAsync(id);
            if (!result)
            {
                return NotFound("العنصر غير موجود");
            }
            return Ok("تم حذف العنصر بنجاح");
        }
    }
}
