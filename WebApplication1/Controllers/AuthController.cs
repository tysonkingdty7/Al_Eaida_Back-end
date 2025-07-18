using EL_Eaida_Applcation.DTO.TokenDTO;
using EL_Eaida_Applcation.DTO.UserDTo;
using EL_Eaida_Applcation.InterFaceServices.IAutherServices;
using EL_Eaida_Applcation.Services;
using Microsoft.AspNetCore.Mvc;

namespace Al_Eaida.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAccountService _acountservices;
        public AuthController(IAccountService acountservices)
        {
            _acountservices = acountservices;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterRequestDto dto)
        {
            var result = await _acountservices.RegisterAsync(dto);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            try
            {
                var result = await _acountservices.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequestDto dto)
        {
            try
            {
                var result = await _acountservices.RefreshTokenAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
