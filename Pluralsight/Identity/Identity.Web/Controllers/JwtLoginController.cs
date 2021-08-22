using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Identity.Web.Models;
using Identity.Domain.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using static Identity.Domain.Models.User;
using Identity.Web.Services;

namespace Identity.Web.Controllers
{
    [Route("[Controller]")]
    public class JwtLoginController : Controller
    {
        private readonly ILogger<JwtLoginController> _logger;
        private readonly IUserRepository _repo;

        public JwtLoginController(ILogger<JwtLoginController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string redirectUrl)
        {
            return Ok(UserViewModel.NullObject);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[Action]")]
        public async Task<IActionResult> SignIn([FromBody] UserViewModel model)
        {
            var user = await _repo.GetByEmailAndPassword(model.Email, model.Password);

            if (user == NullUser)
                return Unauthorized(new 
                {
                    user = new { user.Email, user.Name },
                });

            var token = TokenService.GenerateToken(user);
            model.Password = "";

            return Ok(new { user, token });
        }

        [HttpGet]
        [Route("[Action]")]
        [Authorize]
        public string Authenticate() => $"Authenticated User: {User.Identity.Name}";


        [HttpGet]
        [Route("[Action]")]
        [Authorize(Roles = "admin, user")]
        public string allRoles() => $"User with role: {User.Identity.Name}";

        [HttpGet]
        [Route("[Action]")]
        [Authorize(Roles = "admin")]
        public string AdminOnly() => $"Admin User: {User.Identity.Name}";



    }
}
