using EL_Eaida_Applcation.DTO.MedicalVisitDTO;
using EL_Eaida_Applcation.DTO.MedicineDTO;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using EL_Eaida_Applcation.InterFaceServices;
using EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicielController : Controller
    {  
        protected readonly IMedicineServices _medicalVisitServices;
        public MedicielController(IMedicineServices medicalVisitServices)
        {
            _medicalVisitServices = medicalVisitServices;
        }

        [HttpPost("Addmediciel")]
        public async Task<IActionResult> Addmediciel([FromBody] CreateMedicineDTO value)
        {
            try
            {
                await _medicalVisitServices.CreateMedicineAsync(value);
                return Ok("تمت الإضافة بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء الإضافة: {ex.Message}");
            }
        }
        [HttpGet("GetAllMediciels")]
        public async Task<IActionResult> GetAllMediciels(int pageSize = 10, int pageNumber = 1)
        {
            try
            {
                var medicalVisits = await _medicalVisitServices.GetAllMedicinesAsync(pageSize, pageNumber);
                return Ok(medicalVisits);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الزيارات الطبية: {ex.Message}");
            }
        }
        [HttpGet("GetMedicielById/{id}")]
        public async Task<IActionResult> GetMedicielById(Guid id)
        {
            try
            {
                var medicalVisit = await _medicalVisitServices.GetMedicineByIdAsync(id);
                if (medicalVisit == null)
                {
                    return NotFound("الزيارة الطبية غير موجودة");
                }
                return Ok(medicalVisit);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الزيارة الطبية: {ex.Message}");
            }
        }
        [HttpPut("UpdateMediciel")]
        public async Task<IActionResult> UpdateMediciel([FromBody] UpDateMedicineDTO updateMedicalVisitDto)
        {
            try
            {
                var updatedVisit = await _medicalVisitServices.UpdateMedicineAsync(updateMedicalVisitDto);
                if (updatedVisit == null)
                {
                    return NotFound("الزيارة الطبية غير موجودة");
                }
                return Ok(updatedVisit);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تحديث الزيارة الطبية: {ex.Message}");
            }
        }
        [HttpDelete("DeleteMediciel/{id}")]
        public async Task<IActionResult> DeleteMediciel(Guid id)
        {
            try
            {
                var result = await _medicalVisitServices.DeleteMedicineAsync(id);
                if (!result)
                {
                    return NotFound("الزيارة الطبية غير موجودة");
                }
                return Ok("تم حذف الزيارة الطبية بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء حذف الزيارة الطبية: {ex.Message}");
            }
        }



    }
}
