using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace PlanetaSingli.API.Controllers
{
    [Route("fallback")]
    public class FallbackController : Controller
    {
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
        }
    }
}