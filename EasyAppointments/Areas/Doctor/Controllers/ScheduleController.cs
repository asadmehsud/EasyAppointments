using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
