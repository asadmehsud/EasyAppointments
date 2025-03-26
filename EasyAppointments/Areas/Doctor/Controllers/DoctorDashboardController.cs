using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorDashboardController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            int doctorId = (int)HttpContext.Session.GetInt32("DoctorId")!;
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
            if (jsonData is not null)
            {
                var doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonData);
                return View(doctor);
            }
            return View();
        }
        public async Task<IActionResult> ChangeActiveStatus(int Id, int ActiveStatus)
        {
            var response = await aPIService.GetAsync(APIEndPoint.DoctorDashboardEndPoint.ChangeActiveStatus + Id + "ActiveStatus=" + ActiveStatus);
            return Json(response);
        }
    }
}
