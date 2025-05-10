using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EasyAppointments.API;
using EasyAppointments.Data.Entities.DoctorEntities;
using EasyAppointments.Services.DTOs.DoctorDTOs;
using EasyAppointments.Services.DTOs.DoctorDTOs.ClinicDTOs;
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
            var clinics = await aPIService.GetByIdAsync(APIEndPoint.ClinicEndPoint.GetClinicByDoctor + viewModel.DoctorDto!.Id);
            var schedule = await aPIService.GetByIdAsync(APIEndPoint.ScheduleEndPoint.GetScheduleList + viewModel.DoctorDto!.Id);
            viewModel.ClinicDto = JsonConvert.DeserializeObject<List<GetClinicDto>>(clinics);
            viewModel.ScheduleDto = JsonConvert.DeserializeObject<List<ScheduleDto>>(schedule);
            return View(viewModel);
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
            var token = HttpContext.Request.Cookies["Token"];
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "Role")!.Value;
                var doctorId = jwtToken.Claims.FirstOrDefault(c => c.Type == "DoctorId")!.Value;
                var jsonData = await aPIService.GetByIdAsync(APIEndPoint.DoctorEndPoint.GetById + doctorId);
                if (jsonData is not null)
                {
                    var doctor = JsonConvert.DeserializeObject<DoctorDto>(jsonData);
                    var viewModel = new ViewModelDoctorProfile
                    {
                        DoctorDto = doctor,

                        BreadcrumbDto = new BreadcrumbDto
                        {
                            Title = title,
                        }
                    };
                    return viewModel;
                }
                return null!;
            }
            return null!;
        }

    }
}
