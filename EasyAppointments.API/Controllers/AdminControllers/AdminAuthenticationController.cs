using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthenticationController(AdminAuthenticationService adminAuthenticationService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(AdminRegisterDto adminRegisterDto)
        {
            var response = await adminAuthenticationService.AdminRegistrationAsync(adminRegisterDto);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginDto adminLoginDto)
        {
            var response = await adminAuthenticationService.AdminLoginAsync(adminLoginDto);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
    }
}
