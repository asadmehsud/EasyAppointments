using System.Net;
using EasyAppointments.API;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.Authentication;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthenticationController(IAPIService aPIService, CookiesService cookiesService) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterAdmin(AdminRegisterDto adminRegisterDto)
        {
            var response = await aPIService.PostAsync(adminRegisterDto, APIEndPoint.AdminAuthenticationEndPoint.Post);
            return Json(response);
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginAdmin(AdminLoginDto adminLoginDto)
        {
            var (statusCode, jsonTpken) = await aPIService.LoginAsync(adminLoginDto, APIEndPoint.AdminAuthenticationEndPoint.Login);
            if (statusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(jsonTpken))
            {
                cookiesService.AppendCookie(CookiesKey.AuthToken!, jsonTpken, DateTime.UtcNow.AddDays(1));
                return Json(ResponseType.Success);
            }
            return Json(ResponseType.InvalidEmailOrContact);
        }
    }
}
