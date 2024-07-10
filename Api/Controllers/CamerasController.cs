using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamerasController(ICameraService cameraService) : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(cameraService.GetCameras());
        }
    }
}
