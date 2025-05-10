using EasyAppointments.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EasyAppointments.API.Controllers.SharedControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController(HomePageService homePageService) : ControllerBase
    {
        [HttpGet("GetData")]
        public async Task<IActionResult> GetData()
        {
            var response = await homePageService.GetData();
            return Ok(response);
        }
    }
}
