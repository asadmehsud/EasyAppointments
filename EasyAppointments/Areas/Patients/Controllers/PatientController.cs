using EasyAppointments.API;
using EasyAppointments.Services.DTOs.PatientDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.Areas.Patients.Controllers
{
    [Area("Patients")]
    public class PatientController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(PatientDto patient)
        {
            if (patient.PatientId > 0)
            {
                var response = await aPIService.PutAsync(patient, APIEndPoint.PatientEndPoint.Update);
                return Json(response);
            }
            else
            {
                var response = await aPIService.PostAsync(patient, APIEndPoint.PatientEndPoint.Post);
                return Json(response);
            }
        }

        public IActionResult Login()
        {
            return View();
        }
     
    }
}
