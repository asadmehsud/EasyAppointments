using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAuthenticationController(IAPIService aPIService) : Controller
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
            var response = await aPIService.PostAsync(adminLoginDto, APIEndPoint.AdminAuthenticationEndPoint.Login);
          
            return Json(response);
        }
    }
}
