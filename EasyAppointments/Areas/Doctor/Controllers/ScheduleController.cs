using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class ScheduleController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(ScheduleDto schedule)
        {
            if (schedule.Id > 0)
            {
                var response = await aPIService.PutAsync(schedule, APIEndPoint.ScheduleEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(schedule, APIEndPoint.ScheduleEndPoint.Post);
                return Json(response);
            }
        }
    }
}
