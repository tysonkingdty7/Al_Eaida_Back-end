using EL_Eaida_Applcation.DTO.Prescription;
using EL_Eaida_Applcation.InterFaceServices.IPrescriptionServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : Controller
    {
        protected readonly IPrescriptionServices _prescriptionServices;
        public PrescriptionController(IPrescriptionServices prescriptionServices)
        {
            _prescriptionServices = prescriptionServices;
        }
        [HttpPost("CreatePrescription")]
        public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionDto value)
        {
            try
            {
                await _prescriptionServices.CreatePrescriptionAsync(value);
                return Ok("تمت الإضافة بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء الإضافة: {ex.Message}");
            }
        }
        [HttpGet("GetAllPrescriptions")]
        public async Task<IActionResult> GetAllPrescriptions(int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var prescriptions = await _prescriptionServices.GetAllPrescriptionsAsync(pageSize, pageNumber);
                return Ok(prescriptions);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الوصفات الطبية: {ex.Message}");
            }
        }
        [HttpGet("GetPrescriptionById/{id}")]
        public async Task<IActionResult> GetPrescriptionById(Guid id)
        {
            try
            {
                var prescription = await _prescriptionServices.GetPrescriptionByIdAsync(id);
                if (prescription == null)
                {
                    return NotFound("الوصفة الطبية غير موجودة");
                }
                return Ok(prescription);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الوصفة الطبية: {ex.Message}");
            }
        }
        [HttpPut("UpdatePrescription/{id}")]
        public async Task<IActionResult> UpdatePrescription( [FromBody] UpdatePrescriptionDto updatePrescriptionDto)
        {
            try
            {
                var updatedPrescription = await _prescriptionServices.UpdatePrescriptionAsync( updatePrescriptionDto);
                if (updatedPrescription == null)
                {
                    return NotFound("الوصفة الطبية غير موجودة");
                }
                return Ok(updatedPrescription);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تحديث الوصفة الطبية: {ex.Message}");
            }
        }
        [HttpDelete("DeletePrescription/{id}")]
        public async Task<IActionResult> DeletePrescription(Guid id)
        {
            try
            {
                var result = await _prescriptionServices.DeletePrescriptionAsync(id);
                if (!result)
                {
                    return NotFound("الوصفة الطبية غير موجودة");
                }
                return Ok("تم حذف الوصفة الطبية بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء حذف الوصفة الطبية: {ex.Message}");
            }
        }

    }
}
