using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class AppointmentController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index(int doctorId)
        {
            return View(await aPIService.GetAsync(APIEndPoint.AppointmentEndPoint.Book + doctorId));
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
    }
}
