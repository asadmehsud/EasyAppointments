using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.ClinicDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClinicController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var clinic = new GetClinicDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.ProvinceEndPoint.GetAll);
            if (jsonData is not null)
            {
                var provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(jsonData);
                clinic.Provinces = provinces!;
                return View(clinic);
            }
            return View(clinic);
        }
        public async Task<IActionResult> Save(SaveClinicDto clinic)
        {
            if (clinic.Id > 0)
            {
                var response = await aPIService.PutAsync(clinic, APIEndPoint.ClinicEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(clinic, APIEndPoint.ClinicEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> GetClinics()
        {
            var jsonData = await aPIService.GetAsync(APIEndPoint.ClinicEndPoint.GetAll);
            if (jsonData is not null)
            {
                var clinics = JsonConvert.DeserializeObject<List<GetClinicDto>>(jsonData);
                return PartialView("_ClinicsList", clinics);
            }
            return View();
        }

        public async Task<IActionResult> GetCityByProvinceId(int ProvinceId)
        {
            var clinic = new GetClinicDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.CityEndPoint.GetCityByProvince + ProvinceId);
            if (jsonData is not null)
            {
                var cities = JsonConvert.DeserializeObject<List<GetCityDto>>(jsonData);
                clinic.Cities = cities!;
            return PartialView("_DddlCity", clinic);
            }
            return View();
        }
        public async Task<IActionResult> UpdateClinic(int ClinicId)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.ClinicEndPoint.GetById + ClinicId);
            if (jsonData is not null)
            {
                var clinic = JsonConvert.DeserializeObject<GetClinicDto>(jsonData);
                return PartialView("_EditClinic", clinic);
            }
            return View();
        }

        public async Task<IActionResult> DeleteClinic(int ClinicId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.ClinicEndPoint.Delete + ClinicId);
            return Json(response);
        }
    }
}
