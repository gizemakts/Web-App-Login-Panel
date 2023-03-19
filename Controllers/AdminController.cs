using GizemAktas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GizemAktas.Controllers
{
    public class AdminController : Controller
    {
        private readonly IOptions<List<UserLoginModel>> _users;
        public AdminController(IOptions<List<UserLoginModel>> users)
        {

            _users = users;
        }
        public IActionResult Index(UserLoginModel user)
        {
            var userList = _users.Value;
            List<string> SystemCount = new List<string>();
            List<string> UserCount = new List<string>();
            foreach (var item in userList)
            {
                if(item.Role== "User")
                {
                    UserCount.Add(item.UserName);
                    UserCount.Add(item.Password);
                }
                else if(item.Role== "System")
                {
                    SystemCount.Add(item.UserName);
                    SystemCount.Add(item.Password);
                }
            }
            ViewBag.SystemCount = SystemCount;
            ViewBag.UserCount = UserCount;
            return View(user);
        }
    }
}
