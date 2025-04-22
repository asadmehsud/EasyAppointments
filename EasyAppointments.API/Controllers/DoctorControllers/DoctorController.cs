using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.DoctorControllers
{
    [Route("api/[controller]")]
    public class DoctorController(DoctorService doctorService, CityService cityService, ClinicService clinicService, SpecialityService specialityService) : ControllerBase
    {
        [HttpPost("SaveDoctor")]
        public async Task<IActionResult> Save(DoctorDto doctor)
        {
            int doctorId = await doctorService.SaveAsync(doctor);
            HttpContext.Session.SetInt32("DoctorId", doctorId);
            return doctorId > 0 ? Ok(doctorId) : BadRequest();
        }
        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> Update([FromBody] DoctorDto doctor)
        {
            var response = await doctorService.UpdateAsync(doctor);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAddress")]
        public async Task<IActionResult> LoadLocationDetails()
        {
            DoctorDto doctor = new DoctorDto();
            doctor.Id = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorId"));
            //  doctor.Provinces = await provinceServices.GetAllAsync();
            doctor.Cities = await cityService.GetAllAsync();
            doctor.Clinics = await clinicService.GetAllAsync();
            return Ok(doctor);
        }
        [HttpGet("GetSpecialities")]
        public async Task<IActionResult> LoadSpecialitiesDetails()
        {
            DoctorDto doctor = new DoctorDto();
            doctor.Id = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorId"));
            doctor.Specialities = await specialityService.GetAllAsync();
            return Ok(doctor);
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
        [HttpGet("GetDoctorByIdentifier/{Identifier}")]
        public async Task<IActionResult> GetByIdentifier(string Identifier)
        {

            var doctor = await doctorService.GetByIdentifieAsync(Identifier);
            return doctor is not null ? Ok(doctor) : NotFound(doctor);
        }
        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await doctorService.GetAllAsync();
            return doctors.Any() ? Ok(doctors) : NotFound(doctors);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> CheckDoctor(DoctorDto doctor)
        {
            return Ok(await doctorService.LoginAsync(doctor));
        }
    }
}
