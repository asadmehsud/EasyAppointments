using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDashboardController(IAPIService aPIService) : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> GetDoctors()
        {
            List<DoctorDto> doctors = new List<DoctorDto>();
            var jsonData = await aPIService.GetAsync(APIEndPoint.DoctorEndPoint.GetAll);
            if (jsonData is not null)
            {
                doctors = JsonConvert.DeserializeObject<List<DoctorDto>>(jsonData)!;
                return PartialView("_DoctorsList", doctors);
            }
            return PartialView(doctors);
        }
        public async Task<IActionResult> GetPatients()
        {
            List<PatientDto> patients = new List<PatientDto>();
            var jsonData = await aPIService.GetAsync(APIEndPoint.PatientEndPoint.GetAll);
            if (jsonData is not null)
            {
                patients = JsonConvert.DeserializeObject<List<PatientDto>>(jsonData)!;
                return PartialView("_PatientList", patients);
            }
            return PartialView(patients);
        }
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.DoctorEndPoint.Delete + Id);
            return Json(response);
        }
        public async Task<IActionResult> DeletePatient(int Id)
        {
            var response = await aPIService.DeleteAsync(APIEndPoint.PatientEndPoint.Delete + Id);
            return Json(response);
        } 
        public IActionResult EditAdmin()
        {
            return PartialView("_AdminProfile");
        }
    }
}
