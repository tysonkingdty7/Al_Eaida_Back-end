using Microsoft.AspNetCore.Mvc;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;

namespace EL_Eaida_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // POST: api/Patient
        [HttpPost("Add-Patients")]
        public async Task<IActionResult> AddPatient([FromBody] CreatePatientDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _patientService.AddPatientAsync(dto);
            return Ok(new { message = "Patient added successfully" });
        }

        // PUT: api/Patient
        [HttpPut("UPDate")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _patientService.UpdatePatientAsync(dto);
            if (!updated)
                return NotFound(new { message = "Patient not found" });

            return Ok(new { message = "Patient updated successfully" });
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
          var deleted = await _patientService.DeletePatientAsync(id);
            if (!deleted)
                return NotFound(new { message = "Patient not found" });

            return Ok(new { message = "Patient deleted successfully" });
        }

        // GET: api/Patient/{id}
        [HttpGet("  GetbyId /{id}")]
        public async Task<IActionResult> GetPatientById(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound(new { message = "Patient not found" });

            return Ok(patient);
        }

        // GET: api/Patient?name=...&gender=...&pageNumber=1&pageSize=10
        [HttpGet("Filter")]
        public async Task<IActionResult> GetAllPatients(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? name = null,
            [FromQuery] string? gender = null)
        {
            var patients = await _patientService.GetPatientFilter(pageNumber, pageSize, name, gender);
            return Ok(patients);
        }
    }
}
