using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Samples API";
        }
    }
}
