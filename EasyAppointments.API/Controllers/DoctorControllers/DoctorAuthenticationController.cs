using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.DTOs.DoctorDTOs;
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
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(DoctorLoginDto doctorLoginDto)
        {
            var response = await doctorAuthenticationService.DoctorLoginAsync(doctorLoginDto);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
    }
}
