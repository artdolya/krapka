using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace KrapkaNet.Web.Infrastructure.Controllers;

[Route("api/version")]
[ApiController]
public class VersionController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";
    }
}