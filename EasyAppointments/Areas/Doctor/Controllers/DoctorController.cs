using System.IdentityModel.Tokens.Jwt;
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
     
        public async Task<IActionResult> BasicDetails()
        {
            DoctorDto dto = new DoctorDto();
            var doctorId = GetJwtClaim("DoctorId");
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                dto = JsonConvert.DeserializeObject<DoctorDto>(jsonData)!;
            }
            return PartialView("_BasicDetails", dto);
        }
        public async Task<IActionResult> EducationDetails()
        {
            DoctorDto doctor = new DoctorDto();
            var doctorId = GetJwtClaim("DoctorId");
            var jsonDoctor = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
            if (!string.IsNullOrWhiteSpace(jsonDoctor))
            {
                doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonDoctor)!;
                var jsonSpeciality = await aPIService.GetAsync(APIEndPoint.SpecialityEndPoint.GetAll);
                if (!string.IsNullOrWhiteSpace(jsonSpeciality))
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
            var doctorId = GetJwtClaim("DoctorId");
            var jsonData = await aPIService.GetAsync(APIEndPoint.ClinicEndPoint.GetClinicDetails + doctorId);
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                dto = JsonConvert.DeserializeObject<GetClinicDto>(jsonData)!;
            }
            return PartialView("_Clinic", dto);
        }
        public async Task<IActionResult> ScheduleDetails()
        {
            ScheduleDto dto = new ScheduleDto();
            var doctorId = GetJwtClaim("DoctorId");
            var jsonData = await aPIService.GetAsync(APIEndPoint.ScheduleEndPoint.GetScheduleDetails + doctorId);
            if (!string.IsNullOrWhiteSpace(jsonData))
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
        public async Task<IActionResult> GetCityByProvince(int ProvinceId)
        {
            var clinic = new GetClinicDto();
            var jsonData = await aPIService.GetAsync(APIEndPoint.CityEndPoint.GetCityByProvince + ProvinceId);
            if (!string.IsNullOrWhiteSpace(jsonData))
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
            if (!string.IsNullOrWhiteSpace(jsonData))
            {
                var clinics = JsonConvert.DeserializeObject<List<GetClinicDto>>(jsonData)!;
                doctor.Clinics = clinics;
                return PartialView("_ddlClinic", doctor);
            }
            return View();
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
