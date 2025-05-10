using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController(DayService dayService) : ControllerBase
    {
        [HttpPost("SaveDay")]
        public async Task<IActionResult> Save(DayDto day)
        {
            if (day.Id > 0)
            {
                var response = await dayService.UpdateAsync(day);
                return response > 0 ? Ok(response) : BadRequest(response);
            }
            else
            {
                var response = await dayService.SaveAsync(day);
                return response > 0 ? Ok(response) : BadRequest(response);
            }
        }
        [HttpPut("UpdateDay")]
        public async Task<IActionResult> Update(DayDto day)
        {
            var response = await dayService.UpdateAsync(day);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllDays")]
        public async Task<IActionResult> GetAll()
        {
            var days = await dayService.GetAllAsync();
            return days.Any() ? Ok(days) : NotFound(days);
        }
        [HttpGet("GetDayById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var day = await dayService.GetByIdAsync(Id);
            return day is not null ? Ok(day) : NotFound(day);
        }
        [HttpDelete("DeleteDay/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await dayService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
