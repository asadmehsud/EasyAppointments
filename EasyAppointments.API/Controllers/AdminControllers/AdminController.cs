using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(AdminService adminService) : ControllerBase
    {
        [HttpPost("SaveAdmin")]
        public async Task<IActionResult> Save(AdminRegisterDto admin)
        {
            var response = await adminService.SaveAsync(admin);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> Update(AdminRegisterDto admin)
        {
            var response = await adminService.UpdateAsync(admin);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAll()
        {
            var admins = await adminService.GetAllAsync();
            return admins.Any() ? Ok(admins) : NotFound(admins);
           
        }
        [HttpGet("GetAdminById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var admin = await adminService.GetByIdAsync(Id);
            if (admin is not null)
            {
                return Ok(admin);
            }
            return NotFound(admin);
        }
        [HttpDelete("DeleteAdmin/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await adminService.DeleteAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
