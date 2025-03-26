using EasyAppointments.Services.DoctorServices;
using EasyAppointments.Services.PatientServices;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.PatientControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(DoctorService doctorService, AppointmentService appointmentService) : ControllerBase
    {
        [HttpGet("SearchDoctor")]
        public async Task<IActionResult> SearchDoctor()
        {
            var doctors = await doctorService.GetAllAsync();
            return doctors.Any() ? Ok(doctors) : NotFound(doctors);
        }
        [HttpGet("Book/{doctorId}")]
        public async Task<IActionResult> BookAppointment(int doctorId)
        {
            var appointment = await appointmentService.BookAppointment(doctorId);
            return appointment is not null ? Ok(appointment) : NotFound(appointment);
        }
    }
}
