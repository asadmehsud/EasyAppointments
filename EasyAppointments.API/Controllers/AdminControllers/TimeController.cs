using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController(TimeService timeService) : ControllerBase
    {
        [HttpPost("SaveTime")]
        public async Task<IActionResult> Save(TimeDto time)
        {
            var response = await timeService.SaveAsync(time);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateTime")]
        public async Task<IActionResult> Update(TimeDto time)
        {
            var response = await timeService.UpdateAsync(time);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllTime")]
        public async Task<IActionResult> GetAll()
        {
            var time = await timeService.GetAllAsync();
            return time.Any() ? Ok(time) : NotFound(time);
        }
        [HttpGet("GetTimeById/{Id}")]

        public async Task<IActionResult> GetById(int Id)
        {
            var time = await timeService.GetToShowTimeAsync(Id);
            return time is not null ? Ok(time) : NotFound(time);
        }
        [HttpDelete("DeleteTime/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await timeService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
