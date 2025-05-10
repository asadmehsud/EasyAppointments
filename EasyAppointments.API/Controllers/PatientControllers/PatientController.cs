using EasyAppointments.Services.DTOs.PatientDTOs;
using EasyAppointments.Services.Services.DoctorServices;
using EasyAppointments.Services.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.PatientControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(PatientService patientService) : ControllerBase
    {
        [HttpPost("SavePatient")]
        public async Task<IActionResult> Save(PatientDto patient)
        {
            var response = await patientService.SaveAsync(patient);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> Update(PatientDto patient)
        {
            var response = await patientService.UpdateAsync(patient);
            return response > 0 ? Ok(response) : BadRequest(response);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPatients()
        {
            var response = await patientService.GetAllAsync();
            return response is not null ? Ok(response) : NotFound(response);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await patientService.DeleteAsync(Id);
            return response == 1 ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetPatientById(int Id)
        {
            var response = await patientService.GetByIdAsync(Id);
            return response is not null ? Ok(response) : NotFound(response);
        }
        [HttpGet("GetByIdentifier/{identifier}")]
        public async Task<IActionResult> GetPatientByIdentifier(string identifier)
        {
            var response = await patientService.GetByIdentifierAsync(identifier);
            return response is not null ? Ok(response) : NotFound(response);
        }
    }
}
