using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.Services.DoctorServices;
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
        public async Task<IActionResult> Update([FromBody]ScheduleDto schedule)
        {
            var response = await scheduleService.UpdateAsync(schedule);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("DeleteSchedule/{scheduleId}")]
        public async Task<IActionResult> Delete(int scheduleId)
        {
            var response = await scheduleService.RemoveAsync(scheduleId);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetScheduleDetails/{doctorId}")]
        public async Task<IActionResult> GetScheduleDetails(int doctorId)
        {
            var response = await scheduleService.GetScheduleDetails(doctorId);
            return response is not null ? Ok(response) : NotFound();
        }
        [HttpGet("GetScheduleList/{doctorId}")]
        public async Task<IActionResult> GetScheduleList(int doctorId)
        {
            var response = await scheduleService.GetScheduleList(doctorId);
            return response is not null ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetById/{scheduleId}")]
        public async Task<IActionResult> GetScheduleById(int scheduleId)
        {
            var response = await scheduleService.GetByIdAsync(scheduleId);
            return response is not null ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetToInsertSchedule/{doctorId}")]
        public async Task<IActionResult> GetToInsertSchedule(int doctorId)
        {
            var response = await scheduleService.GetToInsertSchedule(doctorId);
            return response is not null ? Ok(response) : NotFound(response);
        }
    }
}
