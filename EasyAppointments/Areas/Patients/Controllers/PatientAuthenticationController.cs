using EasyAppointments.API;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientAuthenticationController(IAPIService aPIService) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterPatient(PatientRegisterDto patientRegisterDto)
        {
            var response = await aPIService.PostAsync(patientRegisterDto, APIEndPoint.PatientAuthenticationEndPoint.Post);
            return Json(response);
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginPatient(PatientLoginDto patientLoginDto)
        {
            var response = await aPIService.PostAsync(patientLoginDto, APIEndPoint.PatientAuthenticationEndPoint.Login);

            return Json(response);
        }
    }
}
