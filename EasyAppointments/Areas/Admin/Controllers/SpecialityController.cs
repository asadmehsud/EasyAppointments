using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialityController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(SpecialityDto speciality)
        {
            if (speciality.Id > 0)
            {
                var response = await aPIService.PutAsync(speciality, APIEndPoint.SpecialityEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(speciality, APIEndPoint.SpecialityEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetSpecialities()
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.SpecialityEndPoint.GetAll);
            if (jsonData is not null)
            {
                var specialities = JsonConvert.DeserializeObject<List<SpecialityDto>>(jsonData);
                return View("_SpecialityList", specialities);
            }
            return View();
        }

        public async Task<IActionResult> UpdateSpeciality(int SpecialityId)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.SpecialityEndPoint.GetById + SpecialityId);
            if (jsonData is not null)
            {
                var speciality = JsonConvert.DeserializeObject<SpecialityDto>(jsonData);
                return View("_EditSpeciality", speciality);
            }
            return View();
        }

        public async Task<IActionResult> DeleteSpeciality(int SpecialityId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.SpecialityEndPoint.Delete + SpecialityId);
            return Json(response);
        }
    }
}
