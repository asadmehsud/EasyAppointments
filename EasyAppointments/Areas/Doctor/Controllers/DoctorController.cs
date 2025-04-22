using EasyAppointments.API;
using EasyAppointments.Services.DTOs.AdminDTOs;
using EasyAppointments.Services.DTOs.AdminDTOs.CityDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
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
        public async Task<IActionResult> BasicDetails()
        {
            DoctorDto dto = new DoctorDto();
            var doctorId = (int)HttpContext.Session.GetInt32("DoctorId")!;
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
            if (jsonData is not null)
            {
                dto = JsonConvert.DeserializeObject<DoctorDto>(jsonData)!;
            }
            return PartialView("_BasicDetails", dto);
        }
        public async Task<IActionResult> EducationDetails()
        {
            DoctorDto doctor = new DoctorDto();
            var doctorId = (int)HttpContext.Session.GetInt32("DoctorId")!;
            var jsonDoctor = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
            if (jsonDoctor is not null)
            {
                doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonDoctor)!;
                var jsonSpeciality = await aPIService.GetAsync(APIEndPoint.SpecialityEndPoint.GetAll);
                if (jsonSpeciality is not null)
                {
                    var specialities = JsonConvert.DeserializeObject<List<SpecialityDto>>(jsonSpeciality);
                    doctor.Specialities = specialities!;
                }
            }
            return PartialView("_EducationDetails", doctor);
        }
        public async Task<IActionResult> ClinicDetails()
        {
            GetClinicDto dto = new GetClinicDto();
            dto.DoctorId = (int)HttpContext.Session.GetInt32("DoctorId")!;
            var jsonData = await aPIService.GetAsync(APIEndPoint.ClinicEndPoint.GetClinicDetails + dto.DoctorId);
            if (jsonData is not null)
            {
                dto = JsonConvert.DeserializeObject<GetClinicDto>(jsonData)!;
            }
            return PartialView("_Clinic", dto);
        }
        public async Task<IActionResult> ScheduleDetails()
        {
            ScheduleDto dto = new ScheduleDto();
            dto.DoctorId = (int)HttpContext.Session.GetInt32("DoctorId")!;
            var jsonData = await aPIService.GetAsync(APIEndPoint.ScheduleEndPoint.GetScheduleDetails + dto.DoctorId);
            if (jsonData is not null)
            {
                dto = JsonConvert.DeserializeObject<ScheduleDto>(jsonData)!;
            }
            return PartialView("_ScheduleDetails", dto);
        }
        public async Task<IActionResult> Save(DoctorDto doctor, IFormFile Image, IFormFile CNICFrontImage, IFormFile QualificationDocuments)
        {
            if (Image is not null && Image.Length > 0)
            {
                doctor.Image = await GetBytesArrayAsync(Image);
            }
            if (CNICFrontImage is not null && CNICFrontImage.Length > 0)
            {
                doctor.CNICFrontImage = await GetBytesArrayAsync(CNICFrontImage);
            }
            if (QualificationDocuments is not null && QualificationDocuments.Length > 0)
            {
                doctor.QualificationDocuments = await GetBytesArrayAsync(QualificationDocuments);
            }
            var response = await aPIService.PutAsync(doctor, APIEndPoint.DoctorEndPoint.Update);
            return Json(response);
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
            var clinic = new GetClinicDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.CityEndPoint.GetCityByProvince + ProvinceId);
            if (jsonData is not null)
            {
                var cities = JsonConvert.DeserializeObject<List<GetCityDto>>(jsonData)!;
                clinic.Cities = cities;
                return PartialView("_ddlCity", clinic);
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
