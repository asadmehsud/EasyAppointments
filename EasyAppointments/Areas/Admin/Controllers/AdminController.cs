using EasyAppointments.API;
using EasyAppointments.Services.AdminServices;
using EasyAppointments.Services.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static EasyAppointments.API.APIEndPoint;

namespace EasyAppointments.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController(IAPIService aPIService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Save(UpdateAdminDto admin, IFormFile Image)
        {
            if (admin.Id > 0)
            {
                if (Image != null && Image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await Image.CopyToAsync(ms);
                        admin.Image = ms.ToArray();
                    }
                }
                var response = await aPIService.PutAsync(admin, AdminEndPoint.Update);
                return Json(response);
            }
            else
            {
                if (Image != null && Image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await Image.CopyToAsync(ms);
                        admin.Image = ms.ToArray();
                    }
                }
                var response = await aPIService.PostAsync(admin, AdminEndPoint.Post);
                return Json(response);
            }
        }
        public async Task<IActionResult> Getadmins()
        {
            var jsonData = await aPIService.GetAsync(AdminEndPoint.GetAll);
            if (jsonData is not null)
            {
                var admins = JsonConvert.DeserializeObject<List<AdminRegisterDto>>(jsonData);
                return View("_AdminsList", admins);
            }
            return View();
        }

        public async Task<IActionResult> UpdateAdmin(int adminId)
        {
            var jsonData = await aPIService.GetByIdAsync(AdminEndPoint.GetById + adminId);
            if (jsonData is not null)
            {
                var admin = JsonConvert.DeserializeObject<AdminRegisterDto>(jsonData);
                return View("_EditAdmin", admin);
            }
            return View();
        }

        public async Task<IActionResult> DeleteAdmin(int adminId)
        {
            var response = await aPIService.DeleteAsync(AdminEndPoint.Delete + adminId);
            return Json(response);
        }
    }
}
