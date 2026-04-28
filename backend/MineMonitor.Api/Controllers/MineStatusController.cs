using Microsoft.AspNetCore.Mvc;

namespace MineMonitor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MineStatusController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            system = "Real-Time Underground Mine Digital Twin",
            status = "Running",
            realtimeEndpoint = "/mineHub"
        });
    }
}
