using System.Net;
using EasyAppointments.API;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientAuthenticationController(IAPIService aPIService, CookiesService cookiesService) : Controller
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
            var (statusCode, jsonTpken) = await aPIService.LoginAsync(patientLoginDto, APIEndPoint.PatientAuthenticationEndPoint.Login);
            if (statusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(jsonTpken))
            {
                cookiesService.AppendCookie(CookiesKey.AuthToken!, jsonTpken, DateTime.UtcNow.AddDays(1));
                return Json(ResponseType.Success);
            }
            return Json(ResponseType.InvalidEmailOrContact);
        }
    }
}
