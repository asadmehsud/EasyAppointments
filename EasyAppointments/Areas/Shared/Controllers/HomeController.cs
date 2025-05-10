using System.Threading.Tasks;
using EasyAppointments.API;
using EasyAppointments.Services.DTOs.HomePageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Shared.Controllers
{
    [Area("Shared")]
    public class HomeController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.HomePageEndPoint.GetData);
            if (jsonData is not null)
            {
                var vwModel = JsonConvert.DeserializeObject<ViewModelHome>(jsonData);
                return View(vwModel);
            }
            return View();
        }
    }
}
