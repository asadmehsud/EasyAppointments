using EasyAppointments.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorRequestController(DoctorService doctorService) : ControllerBase
    {
        [HttpGet("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(int UserID, int Status)
        {
            var response = await doctorService.ChangeStatus(UserID, Status);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetDoctorsByStatus/{Status}")]
        public async Task<IActionResult> GetAll(int Status)
        {
            var doctors = await doctorService.GetByStatusAsync(Status);
            return doctors.Any() ? Ok(doctors) : NotFound(doctors);
        }
    }
}
