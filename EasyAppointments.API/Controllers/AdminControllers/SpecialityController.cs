using EasyAppointments.Data.Entities.AdminEntities;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.Services.AdminServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController(SpecialityService specialityService) : ControllerBase
    {
        [HttpPost("SaveSpeciality")]
        public async Task<IActionResult> Save(SpecialityDto speciality)
        {
            var response = await specialityService.SaveAsync(speciality);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateSpeciality")]
        public async Task<IActionResult> Update(SpecialityDto speciality)
        {
            var response = await specialityService.UpdateAsync(speciality);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllSpecialities")]
        public async Task<IActionResult> GetAll()
        {
            var specialities = await specialityService.GetAllAsync();
            if (specialities.Any())
            {
                return Ok(specialities);
            }
            return NotFound(specialities);
        }
        [HttpGet("GetSpecialityById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var speciality = await specialityService.GetByIdAsync(Id);
            return speciality is not null ? Ok(speciality) : NotFound(speciality);
        }
        [HttpDelete("DeleteSpeciality/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await specialityService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
