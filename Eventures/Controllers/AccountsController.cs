using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventures.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SignInManager<EventureUser> signInManager;
        private readonly UserManager<EventureUser> userManager;
        private readonly ApplicationDbContext applicationDb;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AccountsController(
             SignInManager<EventureUser> signInManager,
             UserManager<EventureUser> userManager,
             RoleManager<IdentityRole> roleManager,
             ApplicationDbContext applicationDb,
             IMapper mapper
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationDb = applicationDb;
            this.mapper = mapper;
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

            return View();
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
                var user = this.mapper.Map<EventureUser>(model);
               
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

                return RedirectToAction("Login", "Accounts");
            }

            return View();
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = "/Accounts/ExternalLogin";
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public IActionResult ExternalLogin()
        {
            var info = this.signInManager.GetExternalLoginInfoAsync().GetAwaiter().GetResult();
            var email = info.Principal.FindFirstValue(ClaimTypes.Name);

            var user = this.userManager.FindByEmailAsync(email).Result;
            if (user == null)
            {
                user = new EventureUser { UserName = email, Email = email };
                var result = this.userManager.CreateAsync(user).Result;
            }

            this.signInManager.SignInAsync(user, false).GetAwaiter().GetResult();
            
            return this.RedirectToAction("Index", "Home");
        }
    }
}