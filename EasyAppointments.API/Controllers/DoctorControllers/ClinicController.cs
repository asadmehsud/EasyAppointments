using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
using EasyAppointments.Services.Services.AdminServices;
using EasyAppointments.Services.Services.DoctorServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(ClinicService clinicService, CityService cityService) : ControllerBase
    {
        [HttpPost("SaveClinic")]
        public async Task<IActionResult> Save(SaveClinicDto clinic)
        {
            var response = await clinicService.SaveAsync(clinic);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdateClinic")]
        public async Task<IActionResult> Update(SaveClinicDto clinic)
        {
            var response = await clinicService.UpdateAsync(clinic);
            return response == (int)ResponseType.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAllClinics")]
        public async Task<IActionResult> GetAll()
        {
            var clinics = await clinicService.GetAllAsync();
            return clinics.Any() ? Ok(clinics) : NotFound(clinics);
        }
        [HttpGet("GetProvinceByCityId/{provinceId}")]
        public async Task<IActionResult> GetCityByProvinceId(int provinceId)
        {
            var clinic = new GetClinicDto();
            clinic.Cities = await cityService.GetCityByProvinceId(provinceId);
            return clinic is not null ? Ok(clinic) : NotFound(clinic);
        }
        [HttpGet("GetClinicById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var clinic = await clinicService.GetByIdAsync(Id);
            return clinic is not not null ? Ok(clinic) : NotFound(clinic);
        }
        [HttpDelete("DeleteClinic/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await clinicService.RemoveAsync(Id);
            return response > 0 ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetClinicDetails/{doctorId}")]
        public async Task<IActionResult> GetClinicDetails(int doctorId)
        {
            var response = await clinicService.GetClinicDetails(doctorId);
            return response is not null ? Ok(response) : NotFound();
        }
        [HttpGet("GetClinicByDoctor/{doctorId}")]
        public async Task<IActionResult> GetClinicByDoctorId(int doctorId)
        {
            var response = await clinicService.GetClinicByDoctorId(doctorId);
            return Ok(response);
        }
        [HttpGet("GetClinicByIdAndDoctor")]
        public async Task<IActionResult> GetClinicByIdAndDoctor(int clinicId, int doctorId)
        {
            var response = await clinicService.GetClinicByIdAndDoctor(clinicId, doctorId);
            return response is not null ? Ok(response) : NotFound();
        }
    }
}
