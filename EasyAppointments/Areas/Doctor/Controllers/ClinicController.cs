using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
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
        public async Task<IActionResult> UpdateClinic(int clinicId, int doctorId)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.ClinicEndPoint.GetClinicByIdAndDoctor + "clinicId=" + clinicId + "&doctorId=" + doctorId);
            if (jsonData is not null)
            {
                var clinic = JsonConvert.DeserializeObject<GetClinicDto>(jsonData);
                return PartialView("/Areas/Doctor/Views/Doctor/_Clinic.cshtml", clinic);
            }
            return View();
        }
        public async Task<IActionResult> GetToInsertClinic()
        {
            var doctorId = GetJwtClaim("DoctorId");
            var clinic = JsonConvert.DeserializeObject<GetClinicDto>(await aPIService.GetByIdAsync(APIEndPoint.ClinicEndPoint.GetClinicDetails + doctorId));
            return PartialView("/Areas/Doctor/Views/Doctor/_Clinic.cshtml", clinic);
        }

        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.ClinicEndPoint.Delete + clinicId);
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
