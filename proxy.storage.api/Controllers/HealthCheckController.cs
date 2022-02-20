using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace proxy.storage.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HealthCheckController
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/hc")]
        public IActionResult HealthCheck()
        {

            _logger.LogInformation("HC request received");
            return new OkResult();
        }
    }
}