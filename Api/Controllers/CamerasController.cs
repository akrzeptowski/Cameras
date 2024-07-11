using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Dto;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CamerasController(ICameraService cameraService) : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Camera>>> Get()
        {
            var cameras = await cameraService.GetCameras();
            return Ok(cameras);
        }
    }
}
