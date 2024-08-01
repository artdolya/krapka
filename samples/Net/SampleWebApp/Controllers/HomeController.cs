using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("Home controller was called");
            return "Welcome to Samples API";
        }
    }
}
