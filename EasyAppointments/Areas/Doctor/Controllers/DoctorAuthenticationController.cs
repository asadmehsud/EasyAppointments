using EasyAppointments.API;
using EasyAppointments.Data.Repositories;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorAuthenticationController(IAPIService aPIService) : Controller
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
            var response = Convert.ToInt32(await aPIService.PostAsync(doctorLoginDto, APIEndPoint.DoctorAuthenticationEndPoint.Login));
            if (response == (int)ResponseType.Success)
            {
                HttpContext.Session.SetString("Identifier",doctorLoginDto.Identifier);
                return Json(response);
            }
            return Json(response);
        }
    }
}
