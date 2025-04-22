using EasyAppointments.API;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EasyAppointments.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    public class DoctorDashboardController(IAPIService aPIService) : Controller
    {
        public async Task<IActionResult> Dashboard(string title)
        {
            var viewModel = await GetDoctor(title);
            HttpContext.Session.SetInt32("DoctorId", viewModel.doctorDto!.Id);
            var clinics = await aPIService.GetByIdAsync(APIEndPoint.ClinicEndPoint.GetClinicDetails + viewModel.doctorDto!.Id);
            return viewModel is null ? View() : View(viewModel);
        }
        public async Task<IActionResult> ChangeActiveStatus(int Id, int ActiveStatus)
        {
            var response = await aPIService.GetAsync(APIEndPoint.DoctorDashboardEndPoint.ChangeActiveStatus + Id + "&ActiveStatus=" + ActiveStatus);
            return Json(response);
        }
        public async Task<IActionResult> DoctorProfileSetting(string title)
        {
            var viewModel = await GetDoctor(title);
            return viewModel is null ? View() : View(viewModel);
        }
        private async Task<ViewModelDoctorProfile> GetDoctor(string title)
        {
            var doctor = new DoctorDto();
            var doctorIdentifier = HttpContext.Session.GetString("Identifier")!;
            var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetByIdentifier + doctorIdentifier);
            if (jsonData is not null)
            {
                doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonData);
                var viewModel = new ViewModelDoctorProfile
                {
                    doctorDto = doctor,

                    breadcrumbDto = new BreadcrumbDto
                    {
                        Title = title,
                    }
                };
                return viewModel;
            }
            return null!;
        }

    }
}
