using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.Services.AdminServices;
using EasyAppointments.Services.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    public class DoctorController(DoctorService doctorService, CityService cityService, ClinicService clinicService, SpecialityService specialityService) : ControllerBase
    {
        [HttpPost("SaveDoctor")]
        public async Task<IActionResult> Save(DoctorDto doctor)
        {
            var response = await doctorService.SaveAsync(doctor);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> Update([FromBody] DoctorDto doctor)
        {
            var response = await doctorService.UpdateAsync(doctor);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
       
       
        [HttpGet("GetCityByProvince/{provinceId}")]
        public async Task<IActionResult> GetCityByProvince(int provinceId)
        {
            var doctor = new DoctorDto();
            doctor.Cities = await cityService.GetCityByProvinceId(provinceId);
            return Ok(doctor);
        }
        [HttpGet("GetClinicByCityId/{cityId}")]
        public async Task<IActionResult> GetClinicByCity(int cityId)
        {
            var doctor = new DoctorDto();
            doctor.Clinics = await clinicService.GetClinicByCityIdAsync(cityId);
            return Ok(doctor);
        }
        [HttpGet("GetDoctorById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            var doctor = await doctorService.GetByIdAsync(Id);
            return doctor is not null ? Ok(doctor) : NotFound(doctor);
        }
      
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await doctorService.GetAllAsync();
            return doctors.Any() ? Ok(doctors) : NotFound(doctors);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await doctorService.DeleteAsync(Id);
            return response == 1 ? Ok(response) : NotFound(response);
        }
    }
}
