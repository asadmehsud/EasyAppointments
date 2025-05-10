using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.Services.AdminServices;
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
            var (status,token) = await adminAuthenticationService.AdminLoginAsync(adminLoginDto);
            if (status == (int)ResponseType.Success && token != null)
            {
                return Ok(token);
            }
            return BadRequest(status);
        }
    }
}
