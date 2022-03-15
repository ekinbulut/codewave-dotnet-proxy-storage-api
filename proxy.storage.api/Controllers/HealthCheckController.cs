using Microsoft.AspNetCore.Mvc;

namespace proxy.storage.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HealthCheckController
    {
        [HttpGet("/hc")]
        public IActionResult HealthCheck()
        {
            return new OkResult();
        }
    }
}