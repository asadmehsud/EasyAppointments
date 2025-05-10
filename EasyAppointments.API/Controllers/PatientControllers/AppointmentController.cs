using System.Security.AccessControl;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.PatientDTOs;
using EasyAppointments.Services.Services.DoctorServices;
using EasyAppointments.Services.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.PatientControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController( AppointmentService appointmentService) : ControllerBase
    {
        
        [HttpGet("GetAppointmentDetails")]
        public async Task<IActionResult> GetAppointmentDetails(int doctorId, int patientId)
        {
            var appointment = await appointmentService.GetAppointmentDetails(doctorId, patientId);
            return appointment is not null ? Ok(appointment) : NotFound(appointment);
        }
        [HttpPost("Save")]
        public async Task<IActionResult> SaveAppointment(AppointmentDto appointment)
        {
            var response = await appointmentService.SaveAsync(appointment);
            return response == (int)ResponseType.Success ? Ok(response) : NotFound(response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAppointment(AppointmentDto appointment)
        {
            var response = await appointmentService.UpdateAsync(appointment);
            return response == (int)ResponseType.Success ? Ok(response) : NotFound(response);
        }
    }
}
