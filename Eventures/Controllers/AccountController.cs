using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<EventureUser> signInManager;
        private readonly UserManager<EventureUser> userManager;
        private readonly ApplicationDbContext applicationDb;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
             SignInManager<EventureUser> signInManager,
             UserManager<EventureUser> userManager,
             RoleManager<IdentityRole> roleManager,
             ApplicationDbContext applicationDb
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationDb = applicationDb;
        }

        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
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
            if (ModelState.IsValid)
            {
                var result = this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new EventureUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UniqueCitizenNumber = model.UCN,
                };

                var result = userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    IdentityRole role;

                    if (this.applicationDb.Users.Count() == 1)
                    {
                        role = this.applicationDb.Roles.FirstOrDefault(r => r.Name == "Administrator");
                    }
                    else
                    {
                        role = this.applicationDb.Roles.FirstOrDefault(r => r.Name == "User");
                    }

                    var addtoRoleResult = userManager.AddToRoleAsync(user, role.Name).Result;
                }

                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}