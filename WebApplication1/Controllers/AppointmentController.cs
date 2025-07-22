using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;
using EL_Eaida_Applcation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        protected readonly IAppointmentService _appointmentServices;
        public AppointmentController(IAppointmentService appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }
        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentDto value)
        {
            try
            {
                await _appointmentServices.Createappointment(value);
                return Ok("تمت الإضافة بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء الإضافة: {ex.Message}");
            }
        }
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentServices.GetAllAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع المواعيد: {ex.Message}");
            }
        }
        [HttpGet("GetAppointmentById/{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            try
            {
                var appointment = await _appointmentServices.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء استرجاع الموعد: {ex.Message}");
            }
        }
        [HttpPut("UpdateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] UpdateAppointmentDto value)
        {
            try
            {
                var result = await _appointmentServices.UpdateAsync(id, value);
                if (result == null)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء تحديث الموعد: {ex.Message}");
            }
        }
        [HttpDelete("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            try
            {
                var result = await _appointmentServices.DeleteAsync(id);
                if (!result)
                {
                    return NotFound("الموعد غير موجود");
                }
                return Ok("تم حذف الموعد بنجاح");
            }
            catch (Exception ex)
            {
                return BadRequest($"حدث خطأ أثناء حذف الموعد: {ex.Message}");
            }

        }
    }

}
