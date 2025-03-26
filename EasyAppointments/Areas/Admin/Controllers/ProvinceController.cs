using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static EasyAppointments.API.APIEndPoint;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvinceController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(ProvinceDto province)
        {
            if (province.Id > 0)
            {
                var response = await aPIService.PutAsync(province, ProvinceEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(province, ProvinceEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetProvinces()
        {
            var jsonData = await aPIService.GetAsync(ProvinceEndPoint.GetAll);
            if (jsonData is not null)
            {
                var provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(jsonData);
                return View("_ProvinceList", provinces);
            }
            return View();
        }

        public async Task<IActionResult> UpdateProvince(int Id)
        {
            var jsonData = await aPIService.GetByIdAsync(ProvinceEndPoint.GetById + Id);
            if (jsonData is not null)
            {
                var province = JsonConvert.DeserializeObject<ProvinceDto>(jsonData);
                return View("_EditProvince", province);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProvince(int Id)
        {
            var response = await aPIService.DeleteAsync(ProvinceEndPoint.Delete + Id);
            return Json(response);
        }
    }
}
