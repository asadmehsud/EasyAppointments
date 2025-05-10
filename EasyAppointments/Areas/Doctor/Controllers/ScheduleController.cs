using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> UpdateSchedule(int scheduleId)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.ScheduleEndPoint.GetById + scheduleId);
            if (jsonData is not null)
            {
                var schedule = JsonConvert.DeserializeObject<ScheduleDto>(jsonData);
                return PartialView("/Areas/Doctor/Views/Doctor/_ScheduleDetails.cshtml", schedule);
            }
            return View();
        }
        public async Task<IActionResult> GetToInsertSchedule()
        {
            var doctorId = GetJwtClaim("DoctorId");
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.ScheduleEndPoint.GetToInsertSchedule + doctorId);
            if (jsonData is not null)
            {
                var schedule = JsonConvert.DeserializeObject<ScheduleDto>(jsonData);
                return PartialView("/Areas/Doctor/Views/Doctor/_ScheduleDetails.cshtml", schedule);
            }
            return View();
        }
        public async Task<IActionResult> DeleteSchedule(int scheduleId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.ScheduleEndPoint.DeleteSchedule + scheduleId);
            return Json(response);
        }
        private string GetJwtClaim(string claimType)
        {
            var token = HttpContext.Request.Cookies["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
                return claim!;
            }
            return null!;
        }
    }
}
