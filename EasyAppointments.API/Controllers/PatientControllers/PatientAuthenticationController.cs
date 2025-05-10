using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.PatientDTOs;
using EasyAppointments.Services.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.PatientControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAuthenticationController(PatientAuthenticationService patientAuthenticationService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(PatientRegisterDto patientRegisterDto)
        {
            var response = await patientAuthenticationService.PatientRegistrationAsync(patientRegisterDto);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(PatientLoginDto patientLoginDto)
        {
            var (status, token) = await patientAuthenticationService.PatientLoginAsync(patientLoginDto);
            if (status == (int)ResponseType.Success && token != null)
            {
                return Ok(token);
            }
            return BadRequest(status);
        }
    }
}
