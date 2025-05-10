using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAuthenticationController(DoctorAuthenticationService doctorAuthenticationService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(DoctorRegisterDto doctorRegisterDto)
        {
            var response = await doctorAuthenticationService.DoctorRegistrationAsync(doctorRegisterDto);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(DoctorLoginDto doctorLoginDto)
        {
            var (status, token) = await doctorAuthenticationService.DoctorLoginAsync(doctorLoginDto);
            if (status == (int)ResponseType.Success && token != null)
            {
                return Ok(token);
            }
            return BadRequest(status);
        }
    }
}
