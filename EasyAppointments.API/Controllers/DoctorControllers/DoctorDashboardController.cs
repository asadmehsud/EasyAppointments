using EasyAppointments.Services.DoctorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDashboardController(DoctorService doctorService) : ControllerBase
    {
        [HttpGet("ChangeActiveStatus")]
        public async Task<IActionResult> ChangeActiveStatus(int Id, int ActiveStatus)
        {
            var response = await doctorService.ChangeActiveStatus(Id, ActiveStatus);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
    }
}
