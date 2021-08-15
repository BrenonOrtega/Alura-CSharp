using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Identity.Web.Models;
using Identity.Domain.Repositories;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Web.Controllers
{
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IRepository<User> _repo;

        public LoginController(ILogger<LoginController> logger, IRepository<User> repo)
        {
            _logger = logger;
            _repo = repo;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Route("SignIn")]
        [AllowAnonymous]
        public IActionResult LoginAction(string RedirectUrl="/")
        {
            return RedirectToPage("[Controller]/");
        }
    }
}
