using System.Net;
using EasyAppointments.API;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorAuthenticationController(IAPIService aPIService, CookiesService cookiesService) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterDoctor(DoctorRegisterDto doctorRegisterDto)
        {
            var response = await aPIService.PostAsync(doctorRegisterDto, APIEndPoint.DoctorAuthenticationEndPoint.Post);
            return Json(response);
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginDoctor(DoctorLoginDto doctorLoginDto)
        {
            var (statusCode, jsonTpken) = await aPIService.LoginAsync(doctorLoginDto, APIEndPoint.DoctorAuthenticationEndPoint.Login);
            if (statusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(jsonTpken))
            {
                cookiesService.AppendCookie(CookiesKey.AuthToken!, jsonTpken, DateTime.UtcNow.AddDays(1));
                return Json(ResponseType.Success);
            }
            return Json(ResponseType.InvalidEmailOrContact);
        }
    }
} 
