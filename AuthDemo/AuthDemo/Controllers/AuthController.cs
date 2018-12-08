using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthDemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            var model = new AuthUser();
            return View(model);
        }

        //Authenticate the user
        [HttpPost]
        public async Task<IActionResult> Login(AuthUser user)
        {
            //Call the AuthManager to authenticate the user!!
            if (user.UserName == "jdoe" && user.Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(ClaimTypes.Role, "owner"),
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return Redirect("/");
            }
            return View();
        }

        //Remove authentication:
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}