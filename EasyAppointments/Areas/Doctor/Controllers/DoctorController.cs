using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.ClinicDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(DoctorDto doctor, IFormFile Image, IFormFile Qualifications)
        {
            if (doctor.Id > 0)
            {
                if (Qualifications != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await Qualifications.CopyToAsync(ms);
                        doctor.Qualifications = ms.ToArray();
                    }
                }
                var response = await aPIService.PutAsync(doctor, APIEndPoint.DoctorEndPoint.Update);
                return Json(response);
            }
            else
            {
                using (var memorystream = new MemoryStream())
                {
                    await Image.CopyToAsync(memorystream);
                    doctor.Image = memorystream.ToArray();
                }
                var json = await aPIService.PostAsync(doctor, APIEndPoint.DoctorEndPoint.Post);
                var doctorMaxId = JsonConvert.DeserializeObject<int>(json);
                HttpContext.Session.SetInt32("DoctorId", doctorMaxId);
                return Json(doctorMaxId);
            }
        }
        public async Task<byte[]> GetBytesArrayAsync(IFormFile file)
        {
            using (var memorystream = new MemoryStream())
            {
                await file.CopyToAsync(memorystream);
                return memorystream.ToArray();
            }
        }
        public IActionResult LoadPersonalInformation() => View("_PersonalInformation", new DoctorDto());
        public async Task<IActionResult> LoadLocationDetails()
        {
            DoctorDto doctor = new DoctorDto();
            doctor.Id = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorId"));
            var jsonProvinces = await aPIService.GetAsync(APIEndPoint.ProvinceEndPoint.GetAll);
            var jsonCities = await aPIService.GetAsync(APIEndPoint.CityEndPoint.GetAll);
            var jsonClinics = await aPIService.GetAsync(APIEndPoint.ClinicEndPoint.GetAll);
            if (jsonProvinces is not null && jsonCities is not null && jsonClinics is not null)
            {
                doctor.Provinces = JsonConvert.DeserializeObject<List<ProvinceDto>>(jsonProvinces)!;
                doctor.Cities = JsonConvert.DeserializeObject<List<GetCityDto>>(jsonCities)!;
                doctor.Clinics = JsonConvert.DeserializeObject<List<GetClinicDto>>(jsonClinics)!;
                return View("_LocationDetails", doctor);
            }
            return View();
        }
        public async Task<IActionResult> LoadSpecialitiesDetails()
        {
            DoctorDto doctor = new DoctorDto();
            doctor.Id = Convert.ToInt32(HttpContext.Session.GetInt32("DoctorId"));
            var jsonData = await aPIService.GetAsync(APIEndPoint.SpecialityEndPoint.GetAll);
            if (jsonData is not null)
            {
                var specialities = JsonConvert.DeserializeObject<List<SpecialityDto>>(jsonData)!;
                doctor.Specialities = specialities;
                return View("_SpecialitiesDetails", doctor);
            }
            return View();
        }
        public async Task<IActionResult> GetCityByProvince(int ProvinceId)
        {
            var doctor = new DoctorDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.CityEndPoint.GetCityByProvince + ProvinceId);
            if (jsonData is not null)
            {
                var cities = JsonConvert.DeserializeObject<List<GetCityDto>>(jsonData)!;
                doctor.Cities = cities;
                return PartialView("_ddlCity", doctor);
            }
            return View();
        }
        public async Task<IActionResult> GetClinicByCity(int CityId)
        {
            var doctor = new DoctorDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.ClinicEndPoint.GetClinicByCity + CityId);
            if (jsonData is not null)
            {
                var clinics = JsonConvert.DeserializeObject<List<GetClinicDto>>(jsonData)!;
                doctor.Clinics = clinics;
                return PartialView("_ddlClinic", doctor);
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> CheckDoctor(DoctorDto doctor)
        {
            return Json(await aPIService.PostAsync(doctor, APIEndPoint.DoctorEndPoint.Login));
        }
    }
}
