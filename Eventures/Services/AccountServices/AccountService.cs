using System.Linq;
using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Eventures.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext applicationDb;
        private readonly UserManager<EventureUser> userManager;
        private readonly IMapper mapper;

        public AccountService(ApplicationDbContext applicationDb, UserManager<EventureUser> userManager, IMapper mapper)
        {
            this.applicationDb = applicationDb;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public void CreateUser(RegisterViewModel model)
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
        }
    }
}
