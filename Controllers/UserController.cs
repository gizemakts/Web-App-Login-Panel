using GizemAktas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GizemAktas.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(UserLoginModel user)
        {
            return View(user);
        }
    }
}
