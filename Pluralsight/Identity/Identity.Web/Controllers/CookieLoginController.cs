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

namespace Identity.Web.Controllers
{
    [Route("[Controller]")]
    public class CookieLoginController : Controller
    {
        private readonly ILogger<CookieLoginController> _logger;
        private readonly IUserRepository _repo;

        public CookieLoginController(ILogger<CookieLoginController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [AllowAnonymous]
        public IActionResult Index(string redirectUrl)
        {
            ViewData["redirectUrl"] = redirectUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[Action]")]
        public async Task<IActionResult> SignIn(UserViewModel model)
        {
            var user = await _repo.GetByEmailAndPassword(model.Email, model.Password);

            if (user == NullUser)
                return View("Error", new ErrorViewModel());

            var claims = new Claim[]{
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(nameof(user.FavoriteMovie), user.FavoriteMovie)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext?.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: principal,
                properties: new AuthenticationProperties
                {
                    IsPersistent = model.RememberLogin
                }
            );

            return LocalRedirect(model.RedirectUrl ?? "/");
        }
    }
}
