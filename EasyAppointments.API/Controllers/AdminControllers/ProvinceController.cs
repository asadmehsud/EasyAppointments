using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController(ProvinceService provinceService) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("SaveProvince")]
        public async Task<IActionResult> Save(ProvinceDto province)
        {
            var response = await provinceService.SaveAsync(province);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("UpdateProvince")]
        public async Task<IActionResult> Update(ProvinceDto province)
        {
            var response = await provinceService.UpdateAsync(province);
            return response > 0 ? Ok(response) : BadRequest(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllProvinces")]
        public async Task<IActionResult> GetAll()
        {
            var provinces = await provinceService.GetAllAsync();
            return provinces.Any() ? Ok(provinces) : NotFound(provinces);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetProvinceById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var province = await provinceService.GetByIdAsync(Id);
            return province is not null ? Ok(province) : NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("DeleteProvince/{Id}")]
        public async Task<IActionResult> DeleteProvince(int Id)
        {
            var response = await provinceService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
