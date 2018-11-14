using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PandaStorage.Utiities
{
    public class Seeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            var userRoleExists = roleManager.RoleExistsAsync("User").Result;

            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
