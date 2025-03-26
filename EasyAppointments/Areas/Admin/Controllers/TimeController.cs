using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TimeController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(TimeDto time)
        {
            if (time.Id > 0)
            {
                var response = await aPIService.PutAsync(time, APIEndPoint.TimeEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(time, APIEndPoint.TimeEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetTime()
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.TimeEndPoint.GetAll);
            if (jsonData is not null)
            {
                var time = JsonConvert.DeserializeObject<List<TimeDto>>(jsonData);
                return View("_TimeList", time);
            }
            return View();
        }

        public async Task<IActionResult> UpdateTime(int timeId)
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.TimeEndPoint.GetById + timeId);
            if (jsonData is not null)
            {
                var time = JsonConvert.DeserializeObject<TimeDto>(jsonData);
                return View("_EditTime", time);
            }
            return View();
        }

        public async Task<IActionResult> DeleteTime(int timeId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.TimeEndPoint.Delete + timeId);
            return Json(response);
        }
    }
}
