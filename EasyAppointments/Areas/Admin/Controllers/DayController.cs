using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DayController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(DayDto day)
        {
            if (day.Id > 0)
            {
                var response = await aPIService.PutAsync(day, APIEndPoint.DayEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(day, APIEndPoint.DayEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetDays()
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.DayEndPoint.GetAll);
            if (jsonData is not null)
            {
                var days = JsonConvert.DeserializeObject<List<DayDto>>(jsonData);
                return View("_DaysList", days);
            }
            return View();
        }

        public async Task<IActionResult> UpdateDay(int dayId)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DayEndPoint.GetById + dayId);
            if (jsonData is not null)
            {
                var day = JsonConvert.DeserializeObject<DayDto>(jsonData);
                return View("_EditDay", day);
            }
            return View();
        }

        public async Task<IActionResult> DeleteDay(int dayId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.DayEndPoint.Delete + dayId);
            return Json(response);
        }
    }
}
