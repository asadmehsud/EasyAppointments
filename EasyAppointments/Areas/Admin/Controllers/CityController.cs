using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static EasyAppointments.API.APIEndPoint;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var city = new GetCityDto();
            var jsondata = await aPIService.GetAsync(ProvinceEndPoint.GetAll);
            if (jsondata is not null)
            {
                var provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(jsondata);
                city.Provinces = provinces!;
            }
            return View(city);
        }
        public async Task<IActionResult> Save(SaveCityDto city)
        {
            if (city.Id > 0)
            {
                var response = await aPIService.PutAsync(city, CityEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(city, CityEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetCities()
        {
            var jsonData = await aPIService.GetAsync(CityEndPoint.GetAll);
            if (jsonData is not null)
            {
                var cities = JsonConvert.DeserializeObject<List<GetCityDto>>(jsonData);
                return View("_CityList", cities);
            }
            return View();
        }

        public async Task<IActionResult> UpdateCity(int CityId)
        {
            var jsonData = await aPIService.GetByIdAsync(CityEndPoint.GetById + CityId);
            if (jsonData is not null)
            {
                var city = JsonConvert.DeserializeObject<GetCityDto>(jsonData);
                return View("_EditCity", city);
            }
            return View();
        }

        public async Task<IActionResult> DeleteCity(int CityId)
        {
            var response = await aPIService.DeleteAsync(CityEndPoint.Delete + CityId);
            return Json(response);
        }
    }
}
