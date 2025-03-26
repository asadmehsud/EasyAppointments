using EasyAppointments.Services.DTOs.PatientDTOs;
using EasyAppointments.Services.PatientServices;
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
        [HttpPost("Login")]
        public async Task<IActionResult> CheckPatient(PatientDto patient)
        {
            var response = await patientService.LoginAsync(patient);
            return response is true ? Ok(response) : NotFound(response);
        }
    }
}
