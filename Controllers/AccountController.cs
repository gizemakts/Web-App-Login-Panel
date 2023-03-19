using GizemAktas.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GizemAktas.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IOptions<List<UserLoginModel>> _users;
        public AccountController(IOptions<List<UserLoginModel>> users)
        {

            _users = users;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLogin)
        {
            var user = _users.Value.Find(c => c.UserName == userLogin.UserName && c.Password == userLogin.Password);

            if (!(user is null))
            {
                if(user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin", user);
                }
                else if (user.Role == "User") {
                    return RedirectToAction("Index", "User", user);
                } else {
                    return RedirectToAction("Index", "System", user);
                }
            }

            return Redirect("/Account/Error");
        }

        public ActionResult Error() {
            return View();
        }
    }
}
