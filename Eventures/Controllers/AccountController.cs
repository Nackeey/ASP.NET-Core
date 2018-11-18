using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return RedirectToAction("Login", "Account");
        }
    }
}