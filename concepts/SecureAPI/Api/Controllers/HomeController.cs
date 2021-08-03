using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class HomeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok("Hello JWT Auth API!");
        }

    }
}