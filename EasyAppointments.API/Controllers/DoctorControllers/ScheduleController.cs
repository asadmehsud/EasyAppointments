using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    public class ScheduleController(ScheduleService scheduleService) : ControllerBase
    {
        [HttpPost("SaveSchedule")]
        public async Task<IActionResult> Save([FromBody] ScheduleDto schedule)
        {
            var response = await scheduleService.SaveAsync(schedule);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateSchedule")]
        public async Task<IActionResult> Update(ScheduleDto schedule)
        {
            var response = await scheduleService.UpdateAsync(schedule);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetScheduleDetails/{doctorId}")]
        public async Task<IActionResult> GetScheduleDetails(int doctorId)
        {
            var response = await scheduleService.GetScheduleDetails(doctorId);
            return response is not null ? Ok(response) : NotFound();
        }
    }
}
