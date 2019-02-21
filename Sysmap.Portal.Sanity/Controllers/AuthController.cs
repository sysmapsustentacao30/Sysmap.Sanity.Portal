using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sysmap.Portal.Sanity.DAO;
using Sysmap.Portal.Sanity.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Sysmap.Portal.Sanity.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly ILogger _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login loginValue,[FromServices]UserDAO userDAO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool userExist = userDAO.VerifyUser(loginValue.Email, loginValue.Password);

            if (userExist)
            {
                User user = userDAO.GetUser(loginValue.Email);

                string[] userEmail = user.Email.Split("@");

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,userEmail[0]),
                    new Claim(ClaimTypes.Role,user.TypeUser)
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties{};

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                        new ClaimsPrincipal(claimsIdentity),
                                        authProperties);
                string[] sistema = user.TypeUser.Split("-");


                _logger.LogInformation("Login user: {0}", User.Identity.Name);

                if(sistema[0] == "All")
                {
                    return RedirectToAction("Home", "Home");
                }
                else if(sistema[0] == "Vivo")
                {
                    return RedirectToAction("VivoHome", "Vivo");
                }
                else if(sistema[0] == "Natura")
                {
                    return RedirectToAction("NaturaHome", "Natura");
                }
            }

            //Retorna caso usuario nao exista
            ModelState.AddModelError("", "Email e/ou Senha estão incorretos!");
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}