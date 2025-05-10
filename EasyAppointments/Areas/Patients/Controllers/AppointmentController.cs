using System.IdentityModel.Tokens.Jwt;
using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class AppointmentController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index(int doctorId)
        {
            var patientId = GetJwtClaim("PatientId");
            var patientJson = await aPIService.GetByIdAsync(APIEndPoint.PatientEndPoint.GetById + patientId);
            var patient = JsonConvert.DeserializeObject<PatientDto>(patientJson);
            var appointmentJson = await aPIService.GetAsync(APIEndPoint.AppointmentEndPoint.GetAppointmentDetails + doctorId + "&patientId=" + patient!.PatientId);
            var appointment = JsonConvert.DeserializeObject<AppointmentDto>(appointmentJson);
            return View(appointment);
        }
        public async Task<IActionResult> SearchDoctor()
        {

            var jsonData = await aPIService.GetAsync(APIEndPoint.DoctorEndPoint.GetAll);
            if (jsonData != null)
            {
                var doctor = JsonConvert.DeserializeObject<List<DoctorDto>>(jsonData);
                return View(doctor);
            }
            return View();
        }
        public async Task<IActionResult> Save(AppointmentDto appointmentDto)
        {
            if (appointmentDto.Id > 0)
            {
                var response = await aPIService.PutAsync(appointmentDto, APIEndPoint.AppointmentEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(appointmentDto, APIEndPoint.AppointmentEndPoint.Save);
                return Json(response);
            }
        }
        private string GetJwtClaim(string claimType)
        {

            var token = HttpContext.Request.Cookies["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
                return claim!;
            }
            return null!;
        }
    }
}
