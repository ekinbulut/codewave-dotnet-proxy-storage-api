using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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