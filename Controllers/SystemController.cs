using GizemAktas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GizemAktas.Controllers
{
    public class SystemController : Controller
    {
        private readonly IOptions<List<UserLoginModel>> _users;
        public SystemController(IOptions<List<UserLoginModel>> users)
        {

            _users = users;
        }
        public IActionResult Index(UserLoginModel user)
        {
            var userList = _users.Value;
            List<string> UserCount = new List<string>();
            foreach (var item in userList)
            {
                if (item.Role == "User")
                {
                    UserCount.Add(item.UserName);
                }
            }
            ViewBag.UserCount = UserCount;
            return View(user);
        }
    }
}
