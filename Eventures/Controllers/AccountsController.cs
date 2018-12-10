using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services.AccountServices;
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

        public IAccountService AccountService { get; set; }

        public AccountsController(
             SignInManager<EventureUser> signInManager,
             UserManager<EventureUser> userManager,
             RoleManager<IdentityRole> roleManager,
             ApplicationDbContext applicationDb,
             IMapper mapper,
             IAccountService accountService
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.applicationDb = applicationDb;
            this.mapper = mapper;
            this.AccountService = accountService;
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
                this.AccountService.CreateUser(model);

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

        public IActionResult UserAdministration()
        {
            var users = new List<UserViewModel>();
            foreach (var u in this.applicationDb.Users.OrderBy(x => x.UserName).ToList())
            {
                var user = new UserViewModel
                {
                    UserName = u.UserName,
                    Id = u.Id
                };

                var roleId = this.applicationDb.UserRoles.Where(r => r.UserId == u.Id).FirstOrDefault();

                if (roleId != null)
                {
                    user.UserRole = this.roleManager.Roles.Where(r => r.Id == roleId.RoleId).FirstOrDefault().Name;
                }

                users.Add(user);
            }

            return this.View("Users", users);
        }

        public IActionResult Promote(string id)
        {
            var user = this.applicationDb.Users.Where(u => u.Id == id).FirstOrDefault();
            this.userManager.RemoveFromRoleAsync(user, "User").GetAwaiter().GetResult();
            this.userManager.AddToRoleAsync(user, "Administrator").GetAwaiter().GetResult();

            return this.RedirectToAction("UserAdministration");
        }

        public IActionResult Demote(string id)
        {
            var user = this.applicationDb.Users.Where(u => u.Id == id).FirstOrDefault();
            this.userManager.RemoveFromRoleAsync(user, "Administrator").GetAwaiter().GetResult();
            this.userManager.AddToRoleAsync(user, "User").GetAwaiter().GetResult();

            return this.RedirectToAction("UserAdministration");
        }
    }
}