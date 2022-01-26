using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Api.Controllers
{
    [Route("[controller]")]
    public class EventsController : Controller
    {
        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger, IMediator mediator)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}