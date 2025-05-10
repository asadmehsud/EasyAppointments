using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorRequestsController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ChangeStatus(int UserID, int Status)
        {
            var response = await aPIService.GetAsync(APIEndPoint.DoctorRequestEndPoint.ChangeStatus + UserID + "&&Status=" + Status);
            return Json(response);
        }

        public async Task<IActionResult> GetAll(int Status)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorRequestEndPoint.GetDoctorsByStatus + Status);
            var doctors = JsonConvert.DeserializeObject<List<DoctorDto>>(jsonData);
            return PartialView("_DoctorRequestsList", doctors);
        }

        public async Task<IActionResult> ViewPDF(int Id)
        {
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + Id);
            var doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonData);
            return File(doctor!.QualificationDocuments, "application/pdf");
        }
    }
}
