using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PandaStorage.Data;
using PandaStorage.Models;
using PandaStorage.ViewModels;

namespace PandaStorage.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<PandaUser> signInManager;
        private readonly UserManager<PandaUser> userManager;
        private readonly ApplicationDbContext applicationDb;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
             SignInManager<PandaUser> signInManager,
             UserManager<PandaUser> userManager,
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

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel() { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyUsername(RegisterViewModel model)
        {
            if (this.applicationDb.Users.Any(u => u.UserName == model.Username))
            {
                return Json("This username is already taken");
            }

            return Json(true);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new PandaUser
                {
                    UserName = model.Username,
                    Email = model.Email,
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