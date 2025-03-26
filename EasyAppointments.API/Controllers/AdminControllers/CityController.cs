using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(CityService cityService) : ControllerBase
    {
        [HttpPost("SaveCity")]
        public async Task<IActionResult> Save(SaveCityDto city)
        {
            var response = await cityService.SaveAsync(city);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateCity")]
        public async Task<IActionResult> Update(SaveCityDto city)
        {
            var response = await cityService.UpdateAsync(city);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAll()
        {
            var cities = await cityService.GetAllAsync();
            return cities.Any() ? Ok(cities) : NotFound(cities);
        }
        [HttpGet("GetCityById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var city = await cityService.GetByIdAsync(Id);
            return city is not null ? Ok(city) : NotFound(city);
        }
        [HttpGet("GetCityByProvince/{provinceId}")]
        public async Task<IActionResult> GetByProvinceId(int provinceId)
        {
            var city = await cityService.GetCityByProvinceId(provinceId);
            return city is not null ? Ok(city) : NotFound(city);
        }
        [HttpDelete("DeleteCity/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await cityService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
    }
}
