using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
